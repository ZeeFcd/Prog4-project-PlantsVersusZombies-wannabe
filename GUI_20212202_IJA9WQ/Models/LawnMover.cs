using System;
using System.Windows;
using System.Windows.Media;

namespace GUI_20212202_IJA9WQ.Models
{
    public class LawnMover : Moveable
    {
        public LawnMover(int placeX, int placeY, int displayWidth, int displayHeight, float speed)
        {
            this.placeX = placeX;
            this.placeY = placeY;
            this.displayWidth = displayWidth;
            this.displayHeight = displayHeight;
            this.speed = speed;
            this.actualX = placeX;
        }

        public override Geometry Area
        {
            get { return new RectangleGeometry(new Rect(placeX, placeY, displayWidth, displayHeight)); }
        }
        public override void Terminated()
        {
            throw new NotImplementedException();
        }
    }
}
