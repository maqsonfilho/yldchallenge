using Newtonsoft.Json;
using YLDChallenge2.ConsoleApp.Dtos;

namespace YLDChallenge2.ConsoleApp.Client;

public class ChallengeHttpClient : IChallengeHttpClient
{
    private HttpClient _httpClient;

    public ChallengeHttpClient()
    { }

    public async Task<Dictionary<string,ChoiceGameDto>> GetChoiceGamesAsync(int offset, int limit)
    {
        Dictionary<string, ChoiceGameDto> responseApi = new Dictionary<string, ChoiceGameDto>();
        var baseUrl = "https://laamx3l4hq65zwwdziyid2q3tu0rplrh.lambda-url.eu-west-2.on.aws/";
        var numberOfRequests = 0;

        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(baseUrl);
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "YldChallenge2");
        
        var response = await _httpClient.GetAsync($"api/games?offset={offset}&limit={limit}");
        var jsonResponse = await response.Content.ReadAsStringAsync();

        if (!string.IsNullOrEmpty(jsonResponse))
        {
            responseApi = JsonConvert.DeserializeObject<ResponseGamingApiDto>(jsonResponse);
        }

        if (responseApi.TotalItems > 0)
        {
            numberOfRequests = responseApi.TotalItems / 10;
        }

        return responseApi;
    }
}