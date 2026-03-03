using ArtifactsMmo.Sharp.Generated;
using ArtifactsMmo.Sharp.Services.Abstraction;

namespace ArtifactsMmo.Sharp.Services;

public class Runner(
    IGameService game,
    ICharacterService character,
    ICharacterStrategy strategy,
    ArtifactsMmoConfiguration configuration,
    ILogger<Runner> logger) : IRunner
{
    private const double HpRestThreshold = 0.4;        // rest below 40% HP
    private const double InventoryFullThreshold = 0.9; // deposit above 90% slots
    private const int BankX = 4, BankY = 1;           // ⚠️ verify bank coords in-game

    public async Task Run(CancellationToken cancellationToken = default)
    {
        var name = configuration.Characters[0];

        while (!cancellationToken.IsCancellationRequested)
        {
            var characters = await game.GetMyCharactersAsync(cancellationToken);
            var ch = characters.First(c => c.Name == name);

            // 1. HP management
            if (ch.Hp < ch.Max_hp * HpRestThreshold)
            {
                logger.LogInformation("[{name}] HP low ({hp}/{max}), resting", name, ch.Hp, ch.Max_hp);
                await character.RestAsync(name, cancellationToken);
                continue;
            }

            // 2. Inventory management
            var usedSlots = ch.Inventory?.Count ?? 0;
            if (usedSlots >= ch.Inventory_max_items * InventoryFullThreshold)
            {
                logger.LogInformation("[{name}] Inventory {used}/{max} slots used, depositing", name, usedSlots, ch.Inventory_max_items);
                await character.MoveAsync(name, BankX, BankY, cancellationToken);
                foreach (var slot in ch.Inventory ?? [])
                    await character.DepositItemAsync(name, slot.Code, slot.Quantity, cancellationToken);
                continue;
            }

            // 3. Strategy
            await strategy.ExecuteAsync(name, ch, cancellationToken);
        }
    }
}
