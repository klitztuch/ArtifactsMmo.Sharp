namespace ArtifactsMmo.Sharp.Services.Abstraction;

public interface ICharacterService
{
    public Task GatherAsync(CancellationToken cancellationToken = default);
    public Task CraftAsync(string codeName, int quantity, CancellationToken cancellationToken = default);
    public Task MoveAsync(int x, int y, CancellationToken cancellationToken = default);
    public Task WaitAsync(DateTime expiration, CancellationToken cancellationToken = default);
}