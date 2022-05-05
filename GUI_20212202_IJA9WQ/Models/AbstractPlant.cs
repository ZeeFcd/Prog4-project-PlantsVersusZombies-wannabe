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
        public Action<Plant> AbilityEvent;
        protected bool hasfrozenbullet;
        protected bool ispurchaseable;
        protected int timeWhenBought;
        
      
        public Plant(double displayWidth, double displayHeight) // ideiglenes paraméterek
        {
            this.displayWidth = displayWidth;
            this.displayHeight = displayHeight;
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

        public bool Hasfrozenbullet { get => hasfrozenbullet; }
        public bool Ispurchaseable { get => ispurchaseable; }

        public int Price { get; set; }
        public int Cooldown { get; set; }
        public int Range { get; set; }
        public abstract Brush ShopImageBrush { get; }
        public PlantEnum Type { get; protected set; }
        public override Geometry Area
        {
            get { return new  RectangleGeometry(new Rect(placeX, placeY, displayWidth, displayHeight)); }
        }

        public abstract void Ability();
        public abstract Plant GetCopy();
        public void Buy() 
        {
            ispurchaseable = false;
            timeWhenBought = innerClock;
        }
    }
}
