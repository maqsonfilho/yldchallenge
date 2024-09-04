using Microsoft.AspNetCore.Mvc;
using System.Net;
using YldChallenge.Application.Interfaces;
using YldChallenge.Application.Filters;
using YldChallenge.Domain.Responses;

namespace YldChallenge.Api.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IGameService _gameService;

        public GamesController(ILogger<GamesController> logger,
            IGameService gameService)
        {
            this._logger = logger;
            this._gameService = gameService;
        }


        [HttpGet]
        //[Authorize]
        [UserAgentFilter]
        [ProducesResponseType(typeof(GetGamesResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(GetGamesResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetGamesFromFeedAsync([FromQuery] int offset = 0, int limit = 2)
        {
            try
            {
                if (offset < 0 || limit < 0)
                    return BadRequest("Cannot receive values lower than 0");
                if (limit > 10)
                    return BadRequest("Max value for limit is 10");

                var games = await _gameService.GetGamesAsync(offset, limit);

                if (games.TotalItems == 0)
                    return StatusCode((int)HttpStatusCode.NoContent, games);

                _logger.LogInformation($"GetGamesFromFeedAsync got {games.Items.Count()} games from {games.TotalItems} total games");
                return Ok(games);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
