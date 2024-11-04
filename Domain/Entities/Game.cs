using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Game
    {
        public Player playerOne { get; set; }
        public Player playerTwo { get; set; }
        public Round[] rounds { get; set; }
        public Game(int theNumberOfRounds, Player thePlayerOne, Player thePlayerTwo)
        {
            rounds = new Round[theNumberOfRounds];
            playerOne = thePlayerOne;
            playerTwo = thePlayerTwo;
        }

    }
}
