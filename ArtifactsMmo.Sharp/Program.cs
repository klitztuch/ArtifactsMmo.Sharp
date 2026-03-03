using ArtifactsMmo.Sharp;
using ArtifactsMmo.Sharp.Services;
using ArtifactsMmo.Sharp.Services.Abstraction;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddScoped<IRunner, Runner>();
var artifactsMmoConfiguration = builder.Configuration.GetSection("ArtifactsMmo").Get<ArtifactsMmoConfiguration>();
if (artifactsMmoConfiguration is null)
{
    throw new InvalidOperationException("ArtifactsMmo configuration is null");
}

builder.Services.AddSingleton(artifactsMmoConfiguration);
builder.Services.AddHttpClient<IGameService, GameService>((serviceProvider, httpClient) =>
{
    httpClient.BaseAddress = new Uri(artifactsMmoConfiguration.Url);
    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", artifactsMmoConfiguration.ApiToken);
});



builder.Services.AddHttpClient<ICharacterService, CharacterService>((serviceProvider, httpClient) =>
{
    httpClient.BaseAddress = new Uri(artifactsMmoConfiguration.Url);
    httpClient.DefaultRequestHeaders.Authorization =
        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", artifactsMmoConfiguration.ApiToken);
    serviceProvider.GetRequiredService<IGameService>().GetCharactersAsync();
});

var host = builder.Build();
host.Run();