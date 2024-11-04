using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Move
    {
        public MovingType MovingName { get; set; }
        public enum MovingType{
            rock,
            paper,
            scissors
        }
    }
}
