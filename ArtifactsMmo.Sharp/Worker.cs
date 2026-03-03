using ArtifactsMmo.Sharp.Services.Abstraction;

namespace ArtifactsMmo.Sharp;

public class Worker(IServiceScopeFactory serviceScopeFactory, ILogger<Worker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }
            
            using var scope = serviceScopeFactory.CreateScope();

            var runner = scope.ServiceProvider.GetRequiredService<IRunner>();

            await runner.Run(stoppingToken);
            await Task.Delay(1000, stoppingToken);
            
            
            

        }
    }
}