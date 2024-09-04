using YldChallenge.Domain.Responses;

namespace YldChallenge.Application.Interfaces;

public interface IGameService
{
    Task<GetGamesResponse> GetGamesAsync(int offset, int limit);
}
