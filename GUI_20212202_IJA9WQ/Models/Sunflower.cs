using GUI_20212202_IJA9WQ.Assets;
using GUI_20212202_IJA9WQ.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GUI_20212202_IJA9WQ.Models
{
    public class Sunflower : Plant
    {
        public Sunflower(double displayWidth, double displayHeight) : base(displayWidth, displayHeight)
        {
            this.HP = 100;
            this.Price = 50;
            this.Cooldown = 10;
            Type = PlantEnum.Sunflower;
        }
        public override Brush ShopImageBrush
        {
            get { return GameBrushes.SunflowerItemBrush; }
        }
       
        public override Plant GetCopy()
        {
            return new Sunflower(this.displayWidth, this.displayHeight)
            {
                HP = this.HP,
                Damage = this.Damage,
                Price = this.Price,
                Cooldown = this.Cooldown,
                placeX = this.placeX,
                placeY = this.placeY
            };
        }

        protected override void Ability()
        {

        }
        public override void Terminated()
        {
            throw new NotImplementedException();
        }
    }
}

