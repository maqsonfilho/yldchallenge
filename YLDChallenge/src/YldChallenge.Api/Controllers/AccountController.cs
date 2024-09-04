using Microsoft.AspNetCore.Mvc;
using System.Net;
using YldChallenge.Domain.Responses;

namespace YldChallenge.Api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger _logger;

        public AccountController(ILogger<GamesController> logger)
        {
            this._logger = logger;
        }


        [HttpGet]
        //[Authorize]
        [ProducesResponseType(typeof(GetGamesResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Authorize()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
