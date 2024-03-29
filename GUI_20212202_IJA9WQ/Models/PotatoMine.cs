﻿using GUI_20212202_IJA9WQ.Assets;
using GUI_20212202_IJA9WQ.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GUI_20212202_IJA9WQ.Models
{
    public class PotatoMine : Plant
    {
       
        public override Brush ShopImageBrush
        {
            get
            {
                if (ispurchaseable)
                {
                    return GameBrushes.PotatoMineItemBrush;
                }
                else
                {
                    return GameBrushes.Dea_PotatoMineItemBrush;
                }
            }
        }

        public PotatoMine(double displayWidth, double displayHeight) : base(displayWidth, displayHeight)
        {
            this.HP = 100;
            this.Damage = 20;
            this.Price = 25;
            this.Cooldown = 10;
            Type = PlantEnum.Potatomine;
            innerClock = 0;
            State = AttackStateEnum.InActive;
            ispurchaseable = true;
        }

        public override Plant GetCopy()
        {
            return new PotatoMine(this.displayWidth, this.displayHeight)
            {
                HP = this.HP,
                Damage = this.Damage,
                Price = this.Price,
                Cooldown = this.Cooldown,
                placeX = this.placeX,
                placeY = this.placeY,
                AbilityEvent = this.AbilityEvent,
                innerClock = 0
            };
        }

        public override void Ability()
        {
            if (innerClock == 300) 
            {
                State = AttackStateEnum.Normal;
            }           
            else if (deathStartTime != 0 && innerClock - deathStartTime == 50)
            {
                State = AttackStateEnum.Dead;
            }
            
        }

        public override void DamagedBy(OffensiveItem attacker)
        {
            if (deathStartTime==0)
            {
                deathStartTime = innerClock;
                State = AttackStateEnum.Attack;
                AbilityEvent?.Invoke(this);
            }
        }


        public override void TimeChanged()
        {
            if (!ispurchaseable && innerClock - timeWhenBought == 250)
            {
                ispurchaseable = true;
                timeWhenBought = 0;
            }
            base.TimeChanged();
        }
    }
}
