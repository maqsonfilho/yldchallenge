using YLDChallenge2.ConsoleApp.Dtos;

namespace YLDChallenge2.ConsoleApp.Mappings;

public class MapGaming
{
    public static Dictionary<string, ChoiceGameDto> GetChoiceGameDto(ResponseGamingApiDto responseGamingApiDto)
    {
        Dictionary<string, ChoiceGameDto> response = new Dictionary<string, ChoiceGameDto>();
        var groupedList = responseGamingApiDto.Items.GroupBy(i => i.Publisher);
        
        foreach (var item in groupedList)
        {
            ChoiceGameDto choiceGameDto = new ChoiceGameDto();
            response.Add(item.Key, item.);
        }

        return response;
    }
}
