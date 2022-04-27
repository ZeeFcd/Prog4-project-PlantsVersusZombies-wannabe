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
        public override Geometry Area
        {
            get { return new EllipseGeometry(new Rect(placeX, placeY, displayWidth, displayHeight)); }
        }


        public override void Terminated()
        {
            throw new NotImplementedException();
        }
    }
}
