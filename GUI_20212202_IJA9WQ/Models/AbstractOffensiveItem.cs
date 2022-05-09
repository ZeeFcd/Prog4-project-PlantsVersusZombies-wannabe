using GUI_20212202_IJA9WQ.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_IJA9WQ.Models
{
    public abstract class OffensiveItem : GameItem
    {
        protected int innerClock;
        protected int deathStartTime;
        public AttackStateEnum State { get;set; }
        public double Damage { get; set; }
        public double HP { get; set; }

        public int InnerClock
        {
            get { return innerClock; }
        }

        public int DeathStartTime { get => deathStartTime;  }

        public virtual void DamagedBy(OffensiveItem attacker) 
        {
            this.HP -= attacker.Damage;
            if (HP <= 0)
            {
                State = AttackStateEnum.Dead;

            }
        }

        public virtual void TimeChanged()
        {
            innerClock++;
        }

    }
}
