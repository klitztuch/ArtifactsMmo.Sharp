using ArtifactsMmo.Sharp.Services.Abstraction;

namespace ArtifactsMmo.Sharp.Services;

public class Runner(IGameService game, ICharacterService character, ArtifactsMmoConfiguration configuration, ILogger<Runner> logger) : IRunner
{
    public async Task Run(CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Runner running at: {time}", DateTimeOffset.Now);

        var name = configuration.Characters[0];

        while (!cancellationToken.IsCancellationRequested)
        {
            var characters = await game.GetMyCharactersAsync(cancellationToken);

            // copper bar cycle: move to copper ore -> gather 10x -> move to forge -> craft
            await character.MoveAsync(name, 2, 0, cancellationToken);
            foreach (var _ in Enumerable.Range(0, 10))
            {
                await character.GatherAsync(name, cancellationToken);
            }
            await character.MoveAsync(name, 1, 5, cancellationToken);
            await character.CraftAsync(name, "copper", 1, cancellationToken);
        }
    }
}
