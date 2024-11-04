using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Player
    {
        public string Name { get; set; }
        public Player(string theName)
        {
            Name = theName;
        }
    }
}
