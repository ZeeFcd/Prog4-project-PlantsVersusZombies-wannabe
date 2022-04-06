using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GUI_20212202_IJA9WQ.Models
{
    public class LawnMover : GameItem
    {
        private int placeX;
        private int placeY;
        private int displayWidth;
        private int displayHeight;

        public LawnMover(int placeX, int placeY, int displayWidth, int displayHeight)
        {
            this.placeX = placeX;
            this.placeY = placeY;
            this.displayWidth = displayWidth;
            this.displayHeight = displayHeight;
        }

        public override Geometry Area
        {
            get
            {
                return new RectangleGeometry(new Rect(placeX, placeY, displayWidth / 24, displayHeight / 8));
            }
        }
    }
}
