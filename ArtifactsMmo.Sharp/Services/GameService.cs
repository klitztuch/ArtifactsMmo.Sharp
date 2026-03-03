using System.Net.Http.Json;
using ArtifactsMmo.Sharp.Models;
using ArtifactsMmo.Sharp.Services.Abstraction;

namespace ArtifactsMmo.Sharp.Services;

public class GameService(HttpClient httpClient, ArtifactsMmoConfiguration configuration, ILogger<GameService> logger) : IGameService
{
    

    public async Task<List<Character>> GetCharactersAsync(CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Getting characters");
        var response = await httpClient.GetFromJsonAsync<MyCharactersListResponse>($"my/characters", cancellationToken);
        return response?.Data ?? [];
    }
}