using ArtifactsMmo.Sharp.Models;

namespace ArtifactsMmo.Sharp.Services.Abstraction;

public interface IGameService
{
    
    Task<List<Character>> GetCharactersAsync(CancellationToken cancellationToken = default);
}