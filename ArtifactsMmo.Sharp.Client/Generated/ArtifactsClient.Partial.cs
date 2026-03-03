using System.Text.Json.Serialization;

namespace ArtifactsMmo.Sharp.Generated;

public partial class ArtifactsClient
{
    static partial void UpdateJsonSerializerSettings(System.Text.Json.JsonSerializerOptions settings)
    {
        settings.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    }
}
