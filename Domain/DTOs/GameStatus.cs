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
        public int RoundWinnerPlayerNumber;
        public int GameWinnerPlayerNumber;
    }
}
