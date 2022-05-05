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
        protected double placeX;
        protected double placeY;
        protected double displayWidth;
        protected double displayHeight;
        public abstract Geometry Area { get; }
        public Action<GameItem> Terminated;

        public double PlaceX
        {
            get { return placeX; }
            set { placeX = value; }
        }
        public double PlaceY
        {
            get { return placeY; }
            set { placeY = value; }
        }

        public bool IsCollision(GameItem other)
        {
            return Geometry.Combine(
                this.Area,
                other.Area,
                GeometryCombineMode.Intersect, null).GetArea() > 0;
        }

    }
}
