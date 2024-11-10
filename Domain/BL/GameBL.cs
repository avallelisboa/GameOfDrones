using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.BL
{
    public static class GameBL
    {
        public static Result IsGameValid(Game theGame)
        {
            Result aResult = new Result(false, "");

            if (!theGame.IsValid())
               aResult.Message = "The game was not founded";
            else aResult.IsValid = true;

            return aResult;
        }
        public static bool BothPlayersHaveMoved(Game theGame)
        {
            Round aRound = theGame.Rounds.Last();
            return aRound.PlayerOneMove != null && aRound.PlayerTwoMove != null;
        }
        public static bool HasGameEnded(Game theGame)
        {
            int playerOneWins = theGame.playerOne.Wins;
            int playerTwoWins = theGame.playerTwo.Wins;
            return playerOneWins == 3 || playerTwoWins == 3;
        }
        public static int GetGameWinnerNumber(Game theGame)
        {
            
            int playerOneWins = theGame.playerOne.Wins;
            int playerTwoWins = theGame.playerTwo.Wins;
            if (playerOneWins > playerTwoWins)
                return 1;
            else return 2;
        }
    }
}
