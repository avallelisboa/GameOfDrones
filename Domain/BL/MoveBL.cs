using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Entities.Move;
using System.Xml.Linq;

namespace Domain.BL
{
    public static class MoveBL
    {
        public static Result IsMoveValid(int playerNumber, int move)
        {
            Result aResult = new Result
            {
                IsValid = false,
                Message = ""
            };
            if (move > 2 || move < 0)
            {
                aResult.Message = "The move does not exist";
                return aResult;
            }
            else aResult.IsValid = true;

            return aResult;
        }
        public static void Move(int currentRound, int playerNumber, int move, Game theGame)
        {
            Round aRound = theGame.Rounds[currentRound - 1];
            if (playerNumber == 1)
            {
                Move aMove = new Move();
                aMove.MovingName = (MovingType)move;
                aRound.PlayerOneMove = aMove;
            }
            if (playerNumber == 2)
            {
                Move aMove = new Move();
                aMove.MovingName = (MovingType)move;
                aRound.PlayerTwoMove = aMove;
            }
        }
    }
}