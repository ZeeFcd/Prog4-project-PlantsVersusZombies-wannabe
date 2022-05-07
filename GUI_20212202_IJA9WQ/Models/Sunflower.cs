using GUI_20212202_IJA9WQ.Assets;
using System;
using System.Windows.Media;

namespace GUI_20212202_IJA9WQ.Models
{
    public class Sunflower : Plant
    {
        public override Brush ShopImageBrush
        {
            get { return GameBrushes.SunflowerItemBrush; }
        }

        public override Brush GameImageBrush
        {
            get { return GameBrushes.SunflowerBrush; }
        }

        protected override void Ability()
        {

        }
        public override Plant GetCopy()
        {
            return new Sunflower()
            {
                HP = this.HP,
                Damage = this.Damage,
                Price = this.Price,
                Cooldown = 10,
                placeX = this.placeX,
                placeY = this.placeY
            };
        }

        public override void Terminated()
        {
            throw new NotImplementedException();
        }
    }
}

