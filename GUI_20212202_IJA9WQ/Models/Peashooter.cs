using GUI_20212202_IJA9WQ.Assets;
using System;
using System.Windows.Media;

namespace GUI_20212202_IJA9WQ.Models
{
    public class Peashooter : Plant
    {
        public Peashooter()
        {
            this.HP = 100;
            this.Damage = 20;
            this.Price = 100;
            this.Cooldown = 10;
        }

        public override Brush ShopImageBrush
        {
            get { return GameBrushes.PeashooterItemBrush; }
        }

        public override Brush GameImageBrush
        {
            get { return GameBrushes.PeashooterBrush; }
        }

        protected override void Ability()
        {

        }
        public override Plant GetCopy()
        {
            return new Peashooter()
            {
                HP = this.HP,
                Damage = this.Damage,
                Price = this.Price,
                Cooldown = 10,
                placeX = this.placeX,
                placeY = this.placeY,

            };
        }

        public override void Terminated()
        {
            throw new NotImplementedException();
        }
    }
}

