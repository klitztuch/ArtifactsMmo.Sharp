namespace ArtifactsMmo.Sharp.Services.Abstraction;

public interface IRunner
{
    Task Run(CancellationToken cancellationToken = default);
}