using YldChallenge2.ConsoleApp.Domain.Dtos;

namespace YLDChallenge2.ConsoleApp.Dtos;

public class ResponseGamingApiDto
{

    public List<ItemDto> Items { get; set; }

    public int TotalItems { get; set; }
}
