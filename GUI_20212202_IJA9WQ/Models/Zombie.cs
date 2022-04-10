using GUI_20212202_IJA9WQ.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GUI_20212202_IJA9WQ.Models
{
    public class Zombie : Moveable
    {
        bool ally;
        public Zombie(int placeX, int placeY, int displayWidth, int displayHeight, float speed)
        {
            this.placeX = placeX;
            this.placeY = placeY;
            this.displayWidth = displayWidth;
            this.displayHeight = displayHeight;
            this.speed = speed;
            this.actualX = placeX;
            ally=false;
        }

        public override Geometry Area
        {
            get
            {
                return new RectangleGeometry(new Rect(placeX, placeY, displayWidth, displayHeight));
            }
        }

        public override void Terminated()
        {
            throw new NotImplementedException();
        }
    }
}
