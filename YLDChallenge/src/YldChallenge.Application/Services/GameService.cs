using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using YldChallenge.Application.Interfaces;
using YldChallenge.Domain.Dtos;
using YldChallenge.Domain.Responses;

namespace YldChallenge.Application.Services;

public class GameService : IGameService
{
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    public GameService(IMapper mapper,
        IConfiguration configuration)
    {
        this._mapper = mapper;
        this._configuration = configuration;
    }

    public async Task<GetGamesResponse> GetGamesAsync(int offset, int limit)
    {
        var client = new HttpClient();
        var feedUrl = _configuration.GetSection("AppSettings")["FeedUrl"];

        Stream stream = await client.GetStreamAsync(feedUrl);
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        var games = JsonSerializer.Deserialize<IEnumerable<GameDto>>(stream, options);
        if (games == null || !games.Any())
        { 
            return new GetGamesResponse(new List<ItemDto>(), 0);
        }
        games = games.OrderByDescending(p => p.ReleaseDate);
        var count = games.Count();

        if (offset >= count)
            throw new ArgumentException($"offset must be lower than {count} ");

        IEnumerable<GameDto> selectedGames = games.Skip(offset).Take(limit);
        var items = _mapper.Map<IEnumerable<ItemDto>>(selectedGames);

        var response = new GetGamesResponse(items, count);
        return response;
    }
}
