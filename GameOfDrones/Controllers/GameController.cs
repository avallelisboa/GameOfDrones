using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.BL;

namespace GameOfDrones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpGet]
        public IActionResult NewGame(string playerOneName, string playerTwoName)
        {
            Guid id = SystemBL.GetInstance().MakeGame(playerOneName, playerTwoName);
            return Ok(new
            {
                gameId = id,
            });
        }
        [HttpPost]
        public IActionResult MakeMove(Guid gameId,int playerNumber, int playerMove)
        {
            var result = SystemBL.GetInstance().MakeMove(gameId, playerNumber, playerMove);
            return Ok(result);
        }            
    }
}
