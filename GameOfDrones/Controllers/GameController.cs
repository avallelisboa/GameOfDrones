using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.BL;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Domain.DTOs;

namespace GameOfDrones.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpGet]
        [Route("newgame")]
        public IActionResult NewGame(string playerOneName, string playerTwoName)
        {
            Guid id = SystemBL.GetInstance().MakeGame(playerOneName, playerTwoName);
            return Ok(new
            {
                gameId = id,
            });
        }
        [HttpGet]
        [Route("makemove")]
        public IActionResult MakeMove(Guid gameId,int playerNumber,int playerMove)
        {
            GameStatus result = SystemBL.GetInstance().MakeMove(gameId, playerNumber, playerMove);
            return Ok(new
            {
                isValid = result.IsValid,
                message = result.Message,
                roundWinner = result.RoundWinnerPlayerNumber,
                gameWinner = result.GameWinnerPlayerNumber
            });
        }            
    }
}
