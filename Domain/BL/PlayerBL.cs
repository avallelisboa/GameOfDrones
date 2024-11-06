using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BL
{
    public static class PlayerBL
    {
        public static Result IsPlayerValid(int playerNumber, Game theGame)
        {
            Result aResult = new Result(false, "");
            int roundNumber = theGame.CurrentRoundNumber;
            Round aRound = theGame.Rounds[roundNumber - 1];

            if (playerNumber > 2 || playerNumber < 1)
                aResult.Message = "The player does not exist";
            
            else if(playerNumber == 1 && aRound.PlayerOneMove != null)
                aResult.Message = "The player one has already moved";
            
            else if (playerNumber == 2 && aRound.PlayerTwoMove != null)
                aResult.Message = "The player two has already moved";
            
            else aResult.IsValid = true;

            return aResult;
        }
    }
}
