using Domain.Entities.SpecialCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Move : Entity
    {
        public MovingType MovingName { get; set; }

        public enum MovingType{
            rock = 0,
            paper = 1,
            scissors = 2
        }
    }
}
