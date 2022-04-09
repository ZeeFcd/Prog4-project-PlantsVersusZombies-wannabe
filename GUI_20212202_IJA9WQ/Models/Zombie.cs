using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GUI_20212202_IJA9WQ.Models
{
    public class Zombie : GameItem
    {
        private int centerX;
        private int centerY;
        private int displayWidth;
        private int displayHeight;

        public Zombie(int centerX, int centerY, int displayWidth, int displayHeight, float speed)
        {
            this.centerX = centerX;
            this.centerY = centerY;
            this.displayWidth = displayWidth;
            this.displayHeight = displayHeight;
            this.speed = speed;
            this.actualX = centerX;
        }

        public float speed;
        public float actualX;


        public override Geometry Area
        {
            get
            {
                return new RectangleGeometry(new Rect(centerX, centerY, displayWidth, displayHeight));
            }
        }

        public void Move()
        {
            actualX+= speed;
            centerX =(int)Math.Round(actualX);
        }
    }
}
