using System.Text.Json.Serialization;
using YldChallenge.Domain.Dtos;

namespace YldChallenge.Domain.Responses;

public class GetGamesResponse
{
    [JsonPropertyName("items")]
    public IEnumerable<ItemDto> Items { get; private set; }

    [JsonPropertyName("totalItems")]
    public int TotalItems { get; private set; }

    public GetGamesResponse(IEnumerable<ItemDto> items, int totalItems)
    {
        Items = items;
        TotalItems = totalItems;
    }
}
