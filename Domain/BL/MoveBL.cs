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
            Result aResult = new Result(false, "");
            if (move > 2 || move < 0)
            {
                aResult.Message = "The move does not exist";
                return aResult;
            }
            else aResult.IsValid = true;

            return aResult;
        }
        private static void AddFirstMoveOfTheRound(int playerNumber, int move, Game theGame)
        {
            Round aRound = new Round();
            Move aMove = new Move();
            aMove.MovingName = (MovingType)move;
            if (playerNumber == 1)
            {
                aRound.PlayerOneMove = aMove;
            }
            if (playerNumber == 2)
            {
                aRound.PlayerTwoMove = aMove;
            }
            theGame.Rounds.Add(aRound);
        }
        private static void AddLastMoveOfTheRound(int playerNumber, int move,int currentRound, Game theGame)
        {
            Move aMove = new Move();
            aMove.MovingName = (MovingType)move;
            if (playerNumber == 1)
            {
                theGame.Rounds[currentRound - 1].PlayerOneMove = aMove;
            }
            if (playerNumber == 2)
            {
                theGame.Rounds[currentRound - 1].PlayerTwoMove = aMove;
            }
        }
        
        public static void Move(int playerNumber, int move, Game theGame)
        {
            
            int currentRound = theGame.CurrentRoundNumber;
            int count = theGame.Rounds.Count;
            if (count < currentRound)
                AddFirstMoveOfTheRound(playerNumber, move, theGame);
            else
                AddLastMoveOfTheRound(playerNumber, move, currentRound, theGame);
        }
    }
}