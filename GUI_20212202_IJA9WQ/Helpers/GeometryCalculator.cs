using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GUI_20212202_IJA9WQ.Helpers
{
    public class GeometryCalculator
    {
        public Geometry PlantGeometry
        {
            get { return new RectangleGeometry(new Rect(0, 0, 0, 0)); }
        }
        public Geometry ZombieGeometry
        {
            get { return new RectangleGeometry(new Rect(0, 0, 0, 0)); }
        }
        public Geometry LawnMoverGeometry
        {
            get { return new RectangleGeometry(new Rect(0, 0, 0, 0)); }
        }

        public Geometry BulletGeometry
        {
            get { return new RectangleGeometry(new Rect(0, 0, 0, 0)); }
        }
    }
}
