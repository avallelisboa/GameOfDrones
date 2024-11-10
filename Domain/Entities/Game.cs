using Domain.Entities.SpecialCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Game : Entity
    {
        public Guid Id { get; private set; }
        public Player playerOne { get; set; }
        public Player playerTwo { get; set; }
        public List<Round> Rounds;
        public int CurrentRoundNumber;
        public Game(Player thePlayerOne, Player thePlayerTwo)
        {
            Id = Guid.NewGuid();
            Rounds = new List<Round>();
            CurrentRoundNumber = 1;
            playerOne = thePlayerOne;
            playerTwo = thePlayerTwo;
        }

    }
}
