using GUI_20212202_IJA9WQ.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GUI_20212202_IJA9WQ.Models
{
    public class WallNut : Plant
    {
        public override Brush ShopImageBrush
        {
            get
            {
                if (ispurchaseable)
                {
                    return GameBrushes.WallnutItemBrush;
                }
                else
                {
                    return GameBrushes.Dea_WallnutItemBrush;
                }
            }
        }

        public WallNut(double displayWidth, double displayHeight) : base(displayWidth, displayHeight)
        {
            this.HP = 200;
            this.Damage = 0;
            this.Price = 50;
            this.Cooldown = 10;
            Type = Helpers.PlantEnum.Wallnut;
            innerClock = 0;
            ispurchaseable = true;
        }

        public override Plant GetCopy()
        {
            return new WallNut(this.displayWidth, this.displayHeight)
            {
                HP = this.HP,
                Damage = this.Damage,
                Price = this.Price,
                Cooldown = this.Cooldown,
                placeX = this.placeX,
                placeY = this.placeY,
                innerClock = 0
            };
        }

        public override void Ability()
        {
            
        }
        public override void TimeChanged()
        {
            if (!ispurchaseable && innerClock - timeWhenBought == 550)
            {
                ispurchaseable = true;
                timeWhenBought = 0;
            }
            base.TimeChanged();
        }

    }
}
