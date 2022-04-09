using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GUI_20212202_IJA9WQ.Models
{
    public abstract class Plant : GameItem
    {
        public int CenterX { get; set; }
        public int CenterY { get; set; }
        private int displayWidth;
        private int displayHeight;

        public int Price { get; set; }
        public int Cooldown { get; set; }
        public int Range { get; set; }

        protected abstract void Ability();
        public abstract Brush ShopImage();
        public abstract ImageSource Animation();

        public Plant()
        {
            displayWidth = 65;
            displayHeight = 65;
        }

        public override Geometry Area
        {
            get
            {
                return new RectangleGeometry(new Rect(CenterX, CenterY, displayWidth, displayHeight));
            }
        }



        public abstract Plant GetCopy();
    }
}
