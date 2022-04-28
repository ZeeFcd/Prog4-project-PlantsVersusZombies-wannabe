using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GUI_20212202_IJA9WQ.Models
{
    public class Sun : GameItem
    {
        (double, double) speed; 
        public Sun(double placeX, double placeY, double displayWidth, double displayHeight /*(double, double) speed*/)
        {
            this.placeX = placeX;
            this.placeY = placeY;
            this.displayWidth = displayWidth;
            this.displayHeight = displayHeight;
            //this.speed = speed;
        }
        public override Geometry Area
        {
            get { return new EllipseGeometry(new Rect(placeX, placeY, displayWidth, displayHeight)); }
        }

        public (double, double) Speed { get => speed; set => speed = value; }

        public void Move() 
        {

        }

        public override void Terminated()
        {
            throw new NotImplementedException();
        }
    }
}
