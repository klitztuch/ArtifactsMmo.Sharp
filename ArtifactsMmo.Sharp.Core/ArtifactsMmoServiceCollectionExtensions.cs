using System.Net.Http.Headers;
using ArtifactsMmo.Sharp.Core.Services;
using ArtifactsMmo.Sharp.Core.Services.Abstraction;
using ArtifactsMmo.Sharp.Generated;
using Microsoft.Extensions.DependencyInjection;

namespace ArtifactsMmo.Sharp.Core;

public static class ArtifactsMmoServiceCollectionExtensions
{
    public static IServiceCollection AddArtifactsMmo(
        this IServiceCollection services,
        ArtifactsMmoConfiguration config)
    {
        services.AddHttpClient("ArtifactsMmo", client =>
        {
            client.BaseAddress = new Uri(config.Url);
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", config.ApiToken);
        });

        services.AddScoped<IArtifactsClient>(sp =>
        {
            var factory = sp.GetRequiredService<IHttpClientFactory>();
            var http = factory.CreateClient("ArtifactsMmo");
            return new ArtifactsClient(config.Url, http);
        });

        services.AddScoped<ICharacterService, CharacterService>();
        services.AddScoped<IGameService, GameService>();
        services.AddScoped<IAccountService, AccountService>();

        return services;
    }
}
