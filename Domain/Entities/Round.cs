using Domain.Entities.SpecialCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Round : Entity
    {
        public Player Winner { get; set; }
        public Move PlayerOneMove { get; set; }
        public Move PlayerTwoMove { get; set; }
    }
}
