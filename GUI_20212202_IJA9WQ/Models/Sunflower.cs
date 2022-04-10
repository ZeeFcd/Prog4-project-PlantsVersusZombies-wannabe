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
        public override Brush ShopImage
        {
            get { return GameBrushes.SunflowerBrush; }
        }

        public override ImageSource Animation
        {
            get { return AnimatedImages.SunflowerImage; }
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

