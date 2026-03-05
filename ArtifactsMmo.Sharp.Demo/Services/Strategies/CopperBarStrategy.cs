using ArtifactsMmo.Sharp.Core.Services.Abstraction;
using ArtifactsMmo.Sharp.Client.Generated;

namespace ArtifactsMmo.Sharp.Demo.Services.Strategies;

public class CopperBarStrategy(ICharacterService character, IGameService game, ILogger<CopperBarStrategy> logger) : ICharacterStrategy
{
    private const int OreX = 2, OreY = 0;
    private const int ForgeX = 1, ForgeY = 5;
    private const string OreCode = "copper_ore";
    private const string BarCode = "copper_bar";

    private int? _orePerBar;

    public async Task ExecuteAsync(string name, CharacterSchema ch, CancellationToken cancellationToken = default)
    {
        _orePerBar ??= (await game.GetItemAsync(BarCode, cancellationToken))
            .Data.Craft?.Items?.FirstOrDefault(i => i.Code == OreCode)?.Quantity ?? 10;

        var oreCount = ch.Inventory?.FirstOrDefault(s => s.Code == OreCode)?.Quantity ?? 0;

        if (oreCount >= _orePerBar)
        {
            logger.LogInformation("[{name}] Has {count} copper ore, crafting {bars} bar(s)", name, oreCount, oreCount / _orePerBar);
            if (ch.X != ForgeX || ch.Y != ForgeY)
                await character.MoveAsync(name, ForgeX, ForgeY, cancellationToken);
            await character.CraftAsync(name, BarCode, oreCount / _orePerBar.Value, cancellationToken);
        }
        else
        {
            logger.LogInformation("[{name}] Has {count} copper ore, gathering more", name, oreCount);
            if (ch.X != OreX || ch.Y != OreY)
                await character.MoveAsync(name, OreX, OreY, cancellationToken);
            await character.GatherAsync(name, cancellationToken);
        }
    }
}
