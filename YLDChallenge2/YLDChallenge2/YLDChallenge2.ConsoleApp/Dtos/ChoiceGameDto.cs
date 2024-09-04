using System.Text.Json.Serialization;

namespace YLDChallenge2.ConsoleApp.Dtos;

public class ChoiceGameDto
{

    [JsonPropertyName("Name")]
    public string Name { get; set; }

    [JsonPropertyName("ShortDescription")]
    public string ShortDescription { get; set; }

    [JsonPropertyName("Genre")]
    public string[] Genre { get; set; }

    [JsonPropertyName("Platforms")]
    public string[] Platforms { get; set; }

    [JsonPropertyName("ReleaseDate")]
    public DateTime ReleaseDate { get; set; }
}
