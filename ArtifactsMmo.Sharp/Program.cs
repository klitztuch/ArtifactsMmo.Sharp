using System.Net.Http.Headers;
using ArtifactsMmo.Sharp;
using ArtifactsMmo.Sharp.Generated;
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

builder.Services.AddHttpClient("ArtifactsMmo", http =>
{
    http.BaseAddress = new Uri(artifactsMmoConfiguration.Url);
    http.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", artifactsMmoConfiguration.ApiToken);
});

builder.Services.AddScoped<IArtifactsClient>(sp =>
{
    var factory = sp.GetRequiredService<IHttpClientFactory>();
    var http = factory.CreateClient("ArtifactsMmo");
    return new ArtifactsClient(artifactsMmoConfiguration.Url, http);
});

builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IAccountService, AccountService>();

var host = builder.Build();
host.Run();
