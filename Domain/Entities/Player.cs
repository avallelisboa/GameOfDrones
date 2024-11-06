using Domain.Entities.SpecialCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Player : Entity
    {
        public string Name;
        public int Wins;
        public Player(string theName)
        {
            Name = theName;
            Wins = 0;
        }
    }
}
