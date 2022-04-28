using GUI_20212202_IJA9WQ.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GUI_20212202_IJA9WQ.Models
{
    public abstract class Plant : OffensiveItem
    {
        public Plant(double displayWidth, double displayHeight) // ideiglenes paraméterek
        {
            this.displayWidth = displayWidth;
            this.displayHeight = displayHeight;
        }

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
                
        public double DisplayWidth
        {
            get { return displayWidth; }
            set { displayWidth = value; }
        }

        public double DisplayHeight
        {
            get { return displayHeight; }
            set { displayHeight = value; }
        }

        public int Price { get; set; }
        public int Cooldown { get; set; }
        public int Range { get; set; }
        public abstract Brush ShopImageBrush { get; }
        public abstract Brush GameImageBrush { get; }
        public PlantEnum Type { get; protected set; }
        public override Geometry Area
        {
            get { return new  RectangleGeometry(new Rect(placeX, placeY, displayWidth, displayHeight)); }
        }
        protected abstract void Ability();
        public abstract Plant GetCopy();
    }
}
