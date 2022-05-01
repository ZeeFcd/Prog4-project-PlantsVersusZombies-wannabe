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
        bool ismoving;
        public Sun(double placeX, double placeY, double displayWidth, double displayHeight,(double, double) speed)
        {
            this.placeX = placeX;
            this.placeY = placeY;
            this.displayWidth = displayWidth;
            this.displayHeight = displayHeight;
            this.speed = speed;
            ismoving = false;
        }
        public override Geometry Area
        {
            get { return new EllipseGeometry(new Rect(placeX, placeY, displayWidth, displayHeight)); }
        }

        public (double, double) Speed { get => speed; set => speed = value; }
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

        public bool Ismoving { get => ismoving; }

        public void Move(bool stopCondition)
        {
            if (!stopCondition)
            {
                placeX += speed.Item1;
                placeY += speed.Item2;
            }
           
        }

        public void IsInSun(double x,double y)
        {
            
            if (placeX<x && x<placeX+displayWidth && placeY<y &&y<placeY+displayHeight )
            {
                ismoving = true;
            }
           
        }

        public override void Terminated()
        {
            throw new NotImplementedException();
        }
    }
}
