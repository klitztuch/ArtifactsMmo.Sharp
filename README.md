# ArtifactsMmo.Sharp

Bot for [ArtifactsMmo](https://artifactsmmo.com) written in C#. Runs as a background service, looping through game actions for your characters.

Requires [.NET 10](https://dotnet.microsoft.com/download) and an ArtifactsMmo API token.

## Setup

Drop your credentials in `ArtifactsMmo.Sharp/appsettings.Development.json`:

```json
{
  "ArtifactsMmo": {
    "Url": "https://api.artifactsmmo.com/",
    "ApiToken": "<your token>",
    "Characters": ["<character name>"]
  }
}
```

Then run:

```bash
dotnet run --project ArtifactsMmo.Sharp
```

User secrets work too if you'd rather not touch the file:

```bash
dotnet user-secrets set "ArtifactsMmo:ApiToken" "<your token>" --project ArtifactsMmo.Sharp
dotnet user-secrets set "ArtifactsMmo:Characters:0" "<character name>" --project ArtifactsMmo.Sharp
```

## Docker

```bash
docker build -t artifactsmmo-sharp .
docker run -e ArtifactsMmo__ApiToken=<token> -e ArtifactsMmo__Characters__0=<name> artifactsmmo-sharp
```

## Writing strategies

Each tick, the runner handles HP (rest below 40%) and inventory (deposit at 90% full) automatically, then hands off to whatever `ICharacterStrategy` is registered. Right now that's `CopperBarStrategy` — gather copper ore, smelt at the forge.

To add your own, implement `ICharacterStrategy` and swap it in `Program.cs`:

```csharp
public class MyStrategy(ICharacterService character) : ICharacterStrategy
{
    public async Task ExecuteAsync(string name, CharacterSchema ch, CancellationToken ct = default)
    {
        await character.MoveAsync(name, x, y, ct);
        await character.GatherAsync(name, ct);
        // etc.
    }
}
```

`ICharacterService` covers everything — move, gather, craft, fight, rest, bank, grand exchange, tasks. Cooldowns are awaited automatically after each action.
