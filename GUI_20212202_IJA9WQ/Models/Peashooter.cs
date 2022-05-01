﻿using GUI_20212202_IJA9WQ.Assets;
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
    public class Peashooter : Plant
    {
        public Peashooter(double displayWidth, double displayHeight) : base(displayWidth, displayHeight)
        {
            this.HP = 100;
            this.Damage = 20;
            this.Price = 100;
            this.Cooldown = 10;
            Type = PlantEnum.Peashooter;
            innerClock = 0;
        }

        public override Brush ShopImageBrush
        {
            get { return GameBrushes.PeashooterItemBrush; }
        }
        protected override void Ability()
        {

        }
        public override Plant GetCopy()
        {
            return new Peashooter(this.displayWidth, this.displayHeight)
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
    }
}

