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
            innerClock = 0;
            ispurchaseable = true;
        }
        public override Brush ShopImageBrush
        {
            get
            {
                if (ispurchaseable)
                {
                    return GameBrushes.SunflowerItemBrush;
                }
                else
                {
                    return GameBrushes.Dea_SunflowerItemBrush;
                }
            }
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
                placeY = this.placeY,
                AbilityEvent = this.AbilityEvent,
                innerClock = 1,
                Terminated = this.Terminated
            };
        }

        public override void Ability()
        {
            if (innerClock % 550 == 0)
            {
                //produce sun
                AbilityEvent?.Invoke(this);
            }
        }
      

        public override void TimeChanged()
        {
            if (!ispurchaseable && innerClock - timeWhenBought == 100)
            {
                ispurchaseable = true;
                timeWhenBought = 0;
            }
            base.TimeChanged();
        }
    }
}

