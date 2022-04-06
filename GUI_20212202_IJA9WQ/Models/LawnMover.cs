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
        private int centerX;
        private int centerY;
        private int displayWidth;
        private int displayHeight;

        public LawnMover(int placeX, int placeY, int displayWidth, int displayHeight, int speed)
        {
            this.centerX = placeX;
            this.centerY = placeY;
            this.displayWidth = displayWidth;
            this.displayHeight = displayHeight;
            this.speed = speed;
        }

        private int speed;

        public override Geometry Area
        {
            get
            {
                return new RectangleGeometry(new Rect(centerX, centerY, displayWidth, displayHeight));
            }
        }

        public bool Move()
        {
            centerX += speed;
            if (centerX > 1500)
            {
                return true;
            }
            return false;
        }
    }
}
