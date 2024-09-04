using YLDChallenge2.ConsoleApp.Dtos;

namespace YLDChallenge2.ConsoleApp.Client;

public interface IChallengeHttpClient
{
    Task<List<ChoiceGameDto>> GetChoiceGamesAsync(int offset, int limit);
}
