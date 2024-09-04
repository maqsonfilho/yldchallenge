using System.Text.Json.Serialization;

namespace YLDChallenge2.ConsoleApp.Dtos
{
    public class ResponseGameDto
    {
        public List<ChoiceGameDto> Games { get; set; }
    }
}
