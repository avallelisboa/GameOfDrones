using Domain.DTOs;
using Domain.Entities;
using Domain.Entities.SpecialCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Entities.Move;

namespace Domain.BL
{
    public class SystemBL
    {
        private static SystemBL _instance;
        private SystemBL() { }
        public static SystemBL GetInstance()
        {
            if(_instance == null)
                _instance = new SystemBL();

            return _instance;
        }
        private List<Game> _games;
        public Guid MakeGame(string playerOneName, string playerTwoName)
        {
            Player playerOne = new Player(playerOneName);
            Player playerTwo = new Player(playerTwoName);
            int numberOfRound = 5;
            Game aGame = new Game(numberOfRound, playerOne, playerTwo);
            _games.Add(aGame);
            return aGame.Id;
        }
        public Game GetGameById(Guid theId)
        {
            Game aGame = _games.FirstOrDefault(g => g.Id == theId);
            if (aGame == null)
                aGame = new GameNotFounded();

            return aGame;
        }
        public void EndGame(Game theGame)
        {
            _games.Remove(theGame);
        }
        public GameStatus MakeMove(Guid gameId, int playerNumber, int move)
        {
            Game aGame = GetGameById(gameId);

            Result gameValidationResult = GameBL.IsGameValid(aGame);
            if (!gameValidationResult.IsValid)
                return (GameStatus)gameValidationResult;

            Result playerValidationResult = PlayerBL.IsPlayerValid(playerNumber, aGame);
            if (!playerValidationResult.IsValid)
                return (GameStatus)playerValidationResult;

            Result moveValidationResult = MoveBL.IsMoveValid(playerNumber, move);
            if (!moveValidationResult.IsValid)
                return (GameStatus)moveValidationResult;

            int currentRound = aGame.CurrentRoundNumber;
            Round aRound = aGame.Rounds[currentRound - 1];
            MoveBL.Move(currentRound, playerNumber, move, aGame);

            if (GameBL.BothPlayersHaveMoved(aGame))
            {
                GameStatus aStatus = RoundBL.UpdateRoundResult(aGame);

                aGame.CurrentRoundNumber++;

                if (GameBL.HasGameEnded(aGame))
                {
                    aStatus.GameWinnerPlayerNumber = GameBL.GetGameWinnerNumber(aGame);
                    EndGame(aGame);
                }

                return aStatus;
            }          

            return new GameStatus(true, "");
        }
    }
}
