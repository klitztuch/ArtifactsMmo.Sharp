using ArtifactsMmo.Sharp.Core;
using ArtifactsMmo.Sharp.Core.Models.Configuration;
using ArtifactsMmo.Sharp.Core.Services.Abstraction;
using ArtifactsMmo.Sharp.Demo;
using ArtifactsMmo.Sharp.Demo.Services;
using ArtifactsMmo.Sharp.Demo.Services.Abstraction;
using ArtifactsMmo.Sharp.Demo.Services.Strategies;

var builder = Host.CreateApplicationBuilder(args);

var config = builder.Configuration.GetSection("ArtifactsMmo").Get<ArtifactsMmoConfiguration>();
if (config is null)
{
    throw new InvalidOperationException("ArtifactsMmo configuration is null");
}

builder.Services.AddArtifactsMmo(config);
builder.Services.AddSingleton(config);
builder.Services.AddScoped<ICharacterStrategy, CopperBarStrategy>();
builder.Services.AddScoped<IRunner, Runner>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
