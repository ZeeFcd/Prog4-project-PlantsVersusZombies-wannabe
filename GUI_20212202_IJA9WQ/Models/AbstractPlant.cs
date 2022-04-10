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
        public Plant()
        {
            displayWidth = 65;
            displayHeight = 65;
        }

        public int PlaceX
        {
            get { return placeX; }
            set { placeX = value; }
        }
        public int PlaceY
        {
            get { return placeY; }
            set { placeY = value; }
        }
        public int Price { get; set; }
        public int Cooldown { get; set; }
        public int Range { get; set; }
        public abstract Brush ShopImage { get; }
        public abstract ImageSource Animation { get; }
        public override Geometry Area
        {
            get { return new RectangleGeometry(new Rect(placeX, placeY, displayWidth, displayHeight)); }
        }
        protected abstract void Ability();
        public abstract Plant GetCopy();
    }
}
