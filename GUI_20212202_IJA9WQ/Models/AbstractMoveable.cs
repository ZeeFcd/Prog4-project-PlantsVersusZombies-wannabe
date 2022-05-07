using System;

namespace GUI_20212202_IJA9WQ.Models
{
    public abstract class Moveable : OffensiveItem
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
