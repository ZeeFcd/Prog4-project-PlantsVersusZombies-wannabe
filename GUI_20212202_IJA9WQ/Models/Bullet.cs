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
    public class Bullet : Moveable
    {
        public bool IsFrozen { get; set; }
        public Bullet(double placeX, double placeY, double displayWidth, double displayHeight, double speed, bool isfrozen, int damage)
        {
            this.placeX = placeX;
            this.placeY = placeY;
            this.displayWidth = displayWidth;
            this.displayHeight = displayHeight;
            this.speed = speed;
            this.IsFrozen = isfrozen;
            this.Damage = damage;
        }
        public override Geometry Area
        {
            get { return new EllipseGeometry(new Rect(placeX, placeY, displayWidth, displayHeight)); }
        }

        public override bool IsCollision(GameItem other)
        {
            return this.Area.Bounds.IntersectsWith(new Rect(other.PlaceX+ this.displayHeight * 2, other.PlaceY,4,this.displayHeight* this.displayHeight)); 

        }

    }
}
