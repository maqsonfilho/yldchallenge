using System.Text.Json.Serialization;

namespace YldChallenge.Domain.Dtos;

public record PlatformsDto
{
    [JsonPropertyName("windows")]
    public bool Windows { get; set; }

    [JsonPropertyName("mac")]
    public bool Mac { get; set; }

    [JsonPropertyName("linux")]
    public bool Linux { get; set; }
}