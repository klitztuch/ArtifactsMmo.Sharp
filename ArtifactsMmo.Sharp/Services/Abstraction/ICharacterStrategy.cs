using ArtifactsMmo.Sharp.Generated;

namespace ArtifactsMmo.Sharp.Services.Abstraction;

public interface ICharacterStrategy
{
    Task ExecuteAsync(string name, CharacterSchema character, CancellationToken cancellationToken = default);
}
