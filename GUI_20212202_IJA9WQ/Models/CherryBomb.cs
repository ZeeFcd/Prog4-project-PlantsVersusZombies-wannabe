using GUI_20212202_IJA9WQ.Assets;
using GUI_20212202_IJA9WQ.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GUI_20212202_IJA9WQ.Models
{
    public class CherryBomb : Plant
    {
        public override Brush ShopImageBrush
        {
            get { return GameBrushes.CherryBombItemBrush; }
        }

        public CherryBomb(double displayWidth, double displayHeight) : base(displayWidth, displayHeight)
        {
            this.HP = 100;
            this.Damage = 20;
            this.Price = 150;
            this.Cooldown = 10;
            Type = PlantEnum.Cherrybomb;
        }

        public override Plant GetCopy()
        {
            return new CherryBomb(this.displayWidth, this.displayHeight)
            {
                HP = this.HP,
                Damage = this.Damage,
                Price = this.Price,
                Cooldown = this.Cooldown,
                placeX = this.placeX,
                placeY = this.placeY,
            };
        }

        public override void Terminated()
        {
            throw new NotImplementedException();
        }

        protected override void Ability()
        {
            throw new NotImplementedException();
        }
    }
}
