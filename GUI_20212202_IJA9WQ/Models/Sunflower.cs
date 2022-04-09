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
    public class Sunflower : Plant
    {
        protected override void Ability()
        {

        }

        public override Brush ShopImage()
        {
            return GameBrushes.SunflowerBrush;
        }
        public override ImageSource Animation()
        {
            return AnimatedImages.SunflowerImage;
        }

        public override Plant GetCopy()
        {
            return new Sunflower()
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

