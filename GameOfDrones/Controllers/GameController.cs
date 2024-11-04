using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameOfDrones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpGet]
        public IActionResult NewGame(string playerOneName, string playerTwoName)
        {
            try
            {

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult setMove(int gameId,string playerOneMove, string playerTwoMove) {
            return Ok();
        }
    }
}
