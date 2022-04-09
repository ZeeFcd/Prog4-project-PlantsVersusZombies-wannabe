using GUI_20212202_IJA9WQ.Assets;
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
    public class Peashooter : Plant
    {
        protected override void Ability()
        {

        }

        public Peashooter()
        {
            this.HP = 100;
            this.Damage = 20;
            this.Price = 100;
            this.Cooldown = 10;
        }

        public override Brush ShopImage()
        {
            return GameBrushes.PeashooterBrush;
        }
        public override Brush Animation()
        {
            return GameBrushes.PeashooterBrush;
        }

        public override Plant GetCopy()
        {
            return new Peashooter()
            {
                HP = this.HP,
                Damage = this.Damage,
                Price = this.Price,
                Cooldown = 10,
                CenterX = this.CenterX,
                CenterY = this.CenterY
            };
        }
    }
}

