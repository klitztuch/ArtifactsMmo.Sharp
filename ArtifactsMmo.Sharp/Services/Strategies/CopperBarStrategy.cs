using ArtifactsMmo.Sharp.Generated;
using ArtifactsMmo.Sharp.Services.Abstraction;

namespace ArtifactsMmo.Sharp.Services.Strategies;

public class CopperBarStrategy(ICharacterService character, ILogger<CopperBarStrategy> logger) : ICharacterStrategy
{
    private const int OreX = 2, OreY = 0;
    private const int ForgeX = 1, ForgeY = 5;
    private const string OreCode = "copper_ore";
    private const string BarCode = "copper";
    private const int OrePerBar = 8;

    public async Task ExecuteAsync(string name, CharacterSchema ch, CancellationToken cancellationToken = default)
    {
        var oreCount = ch.Inventory?.FirstOrDefault(s => s.Code == OreCode)?.Quantity ?? 0;

        if (oreCount >= OrePerBar)
        {
            logger.LogInformation("[{name}] Has {count} copper ore, crafting {bars} bar(s)", name, oreCount, oreCount / OrePerBar);
            await character.MoveAsync(name, ForgeX, ForgeY, cancellationToken);
            await character.CraftAsync(name, BarCode, oreCount / OrePerBar, cancellationToken);
        }
        else
        {
            logger.LogInformation("[{name}] Has {count} copper ore, gathering more", name, oreCount);
            await character.MoveAsync(name, OreX, OreY, cancellationToken);
            await character.GatherAsync(name, cancellationToken);
        }
    }
}
