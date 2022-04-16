using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GUI_20212202_IJA9WQ.Models
{
    public abstract class GameItem
    {
        protected int placeX;
        protected int placeY;
        protected int displayWidth;
        protected int displayHeight;
        public abstract Geometry Area { get; }
        public abstract void Terminated();
        
        public bool IsCollision(GameItem other)
        {
            return Geometry.Combine(
                this.Area,
                other.Area,
                GeometryCombineMode.Intersect, null).GetArea() > 0;
        }

    }
}
