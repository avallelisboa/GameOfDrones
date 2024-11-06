using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BL
{
    public static class RoundBL
    {
        public static int GetRoundWinner(Round theRound)
        {
            Move playerOneMove = theRound.PlayerOneMove;
            Move playerTwoMove = theRound.PlayerTwoMove;
            int playerOneMoveNumber = (int)playerOneMove.MovingName;
            int playerTwoMoveNumber = (int)playerTwoMove.MovingName;

            if (playerOneMoveNumber == playerTwoMoveNumber)
                return 0;
            if (playerOneMoveNumber == 0 && playerTwoMoveNumber == 2)
                return 1;
            if (playerOneMoveNumber == 2 && playerTwoMoveNumber == 0)
                return 2;
            if (playerOneMoveNumber > playerTwoMoveNumber)
                return 1;
            else
                return 2;
        }
    }
}
