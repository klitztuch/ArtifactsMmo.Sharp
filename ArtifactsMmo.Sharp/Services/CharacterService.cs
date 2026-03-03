using System.Net.Http.Json;
using ArtifactsMmo.Sharp.Models;
using ArtifactsMmo.Sharp.Services.Abstraction;

namespace ArtifactsMmo.Sharp.Services;

public class CharacterService(string name, ILogger<CharacterService> logger, HttpClient httpClient) : ICharacterService
{
    public async Task GatherAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Gathering");
        var response = await httpClient.PostAsync($"my/{name}/action/gathering", null, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            logger.LogWarning("Gathering failed");
            return;
        }

        var body = await response.Content.ReadFromJsonAsync<SkillResponse>(cancellationToken);
        if (body == null)
        {
            logger.LogError("Gathering failed - body is null");
            return;
        }

        await WaitAsync(body.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task CraftAsync(string codeName, int quantity, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Crafting {codeName} x{quantity}", codeName, quantity);
        var response = await httpClient.PostAsJsonAsync($"my/{name}/action/crafting", new { code = codeName, quantity }, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            logger.LogWarning("Crafting failed");
            HandleErrorStatusCode(response);
            return;
        }

        var body = await response.Content.ReadFromJsonAsync<SkillResponse>(cancellationToken);
        if (body == null)
        {
            logger.LogError("Crafting failed - body is null");
            return;
        }

        await WaitAsync(body.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task MoveAsync(int x, int y, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Moving to {x}, {y}", x, y);
        var response = await httpClient.PostAsJsonAsync($"my/{name}/action/move", new { x, y }, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            logger.LogWarning("Moving failed");
            HandleErrorStatusCode(response);
            return;
        }

        var body = await response.Content.ReadFromJsonAsync<SkillResponse>(cancellationToken);
        if (body == null)
        {
            logger.LogError("Moving failed - body is null");
            return;
        }

        await WaitAsync(body.Data.Cooldown.Expiration, cancellationToken);
    }

    private void HandleErrorStatusCode(HttpResponseMessage response)
    {
        switch ((int)response.StatusCode)
        {
            case 499:
                logger.LogError("Character in cooldown.");
                break;
            case 598:
                logger.LogError("Workshop not found on this map.");
                break;
        }
    }

    public async Task WaitAsync(DateTime expiration, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Waiting until {time}", expiration);
        var delay = expiration - DateTime.UtcNow;
        if (delay < TimeSpan.Zero)
            return;
        await Task.Delay(delay, cancellationToken);
        logger.LogInformation("Waiting finished at {time}", DateTimeOffset.UtcNow);
    }
}