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
        public Peashooter()
        {
            this.HP = 100;
            this.Damage = 20;
            this.Price = 100;
            this.Cooldown = 10;
        }

        public override Brush ShopImage 
        {
            get { return GameBrushes.PeashooterBrush; }
        }

        public override ImageSource Animation
        {
            get { return AnimatedImages.PeashooterImage; }
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

