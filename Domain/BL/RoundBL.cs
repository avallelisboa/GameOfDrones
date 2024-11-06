using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public static GameStatus UpdateRoundResult(Game theGame)
        {
            GameStatus aStatus = new GameStatus(true, "");

            Round currentRound = theGame.Rounds[theGame.CurrentRoundNumber - 1];
            Move playerOneMove = currentRound.PlayerOneMove;
            Move playerTwoMove = currentRound.PlayerTwoMove;

            int winnerNumber = GetRoundWinner(currentRound);
            if (winnerNumber == 1)
            {
                theGame.playerOne.Wins++;
                currentRound.Winner = theGame.playerOne;
            }
            if (winnerNumber == 2)
            {
                theGame.playerTwo.Wins++;
                currentRound.Winner = theGame.playerTwo;
            }
            aStatus.RoundWinnerPlayerNumber = winnerNumber;
            return aStatus;
        }
    }
}
