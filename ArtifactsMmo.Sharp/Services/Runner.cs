using ArtifactsMmo.Sharp.Services.Abstraction;

namespace ArtifactsMmo.Sharp.Services;

public class Runner(IGameService game, ArtifactsMmoConfiguration configuration, ILogger<Runner> logger) : IRunner
{
    public async Task Run(CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Runner running at: {time}", DateTimeOffset.Now);
        while (!cancellationToken.IsCancellationRequested)
        {
            var characters = await game.GetCharactersAsync(cancellationToken);
            // cooper bar cycle
            await game.MoveAsync(2, 0, cancellationToken);
            foreach (var count in Enumerable.Range(0, 10))
            {
                await game.GatherAsync(cancellationToken);
            }
            await game.MoveAsync(1, 5, cancellationToken);
            await game.CraftAsync("copper", 1, cancellationToken);
        }
    }
}