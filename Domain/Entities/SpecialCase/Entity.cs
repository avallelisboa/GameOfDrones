﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.SpecialCase
{
    public abstract class Entity
    {
        public virtual bool IsValid()
        {
            return true;
        }
    }
}
