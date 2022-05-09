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
            get
            {
                if (ispurchaseable)
                {
                    
                    return GameBrushes.CherryBombItemBrush;
                }
                else
                {
                    return GameBrushes.Dea_CherryBombItemBrush;
                } 
            }
        }

        public CherryBomb(double displayWidth, double displayHeight) : base(displayWidth, displayHeight)
        {
            this.HP = 100;
            this.Damage = 20;
            this.Price = 150;
            this.Cooldown = 20;
            Type = PlantEnum.Cherrybomb;
            innerClock = 0;
            ispurchaseable = true;
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
                AbilityEvent=this.AbilityEvent,
                innerClock=0,
                Terminated=this.Terminated
                
            };
        }

        public override void Ability()
        {
            if (innerClock == 11 )
            {
                State = AttackStateEnum.Attack;
                deathStartTime = innerClock;
                //explode
                AbilityEvent?.Invoke(this);
            }
            else if (deathStartTime != 0 && innerClock - deathStartTime == 14)
            {
                State = AttackStateEnum.Dead;
            }            
        }

        public override void TimeChanged()
        {
            if (!ispurchaseable && innerClock-timeWhenBought==1200)
            {
                ispurchaseable = true;
                timeWhenBought = 0;
            }
          
            base.TimeChanged();
        }
    }
}
