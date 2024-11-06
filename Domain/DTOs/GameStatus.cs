using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class GameStatus : Result
    {
        public GameStatus() { }
        public GameStatus(bool theIsValid,string theMessage):base(theIsValid,theMessage) { }

        public int RoundWinnerPlayerNumber;
        public int GameWinnerPlayerNumber;
    }
}
