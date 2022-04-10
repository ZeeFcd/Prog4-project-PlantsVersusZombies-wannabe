﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_IJA9WQ.Models
{
    public abstract class Moveable:OffensiveItem
    {
        protected float speed;
        protected float actualX;
        public void Move() 
        {
            actualX += speed;
            placeX = (int)Math.Round(actualX);
        }
    }
}
