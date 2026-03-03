namespace ArtifactsMmo.Sharp.Demo.Services.Abstraction;

public interface IRunner
{
    Task Run(CancellationToken cancellationToken = default);
}
