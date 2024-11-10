using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.SpecialCase
{
    public class GameNotFounded : Game
    {
        public GameNotFounded() : base(null, null){}

        public override bool IsValid()
        {
            return false;
        }
        public override string ToString()
        {
            return "The game was not founded";
        }
    }
}
