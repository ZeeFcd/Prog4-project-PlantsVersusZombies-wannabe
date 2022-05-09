using GUI_20212202_IJA9WQ.Assets;
using GUI_20212202_IJA9WQ.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GUI_20212202_IJA9WQ.Models
{
    public class Zombie : Moveable
    {
        public Zombie(double placeX, double placeY, double displayWidth, double displayHeight, double speed, double damage, double hp)
        {
            this.placeX = placeX;
            this.placeY = placeY;
            this.displayWidth = displayWidth;
            this.displayHeight = displayHeight;
            this.speed = speed;
            this.ZombieState = ZombieStateEnum.Normal;
            this.PlaceGameMatrixX = -1;
            this.PlaceGameMatrixY = -1;
            this.State = AttackStateEnum.Normal;
            innerClock = 0;
            Damage = damage;
            HP = hp;
        }

        public int PlaceGameMatrixX { get; set; }
        public int PlaceGameMatrixY { get; set; }

        public override Geometry Area
        {
            get
            {
                return new RectangleGeometry(new Rect(placeX, placeY, displayWidth, displayHeight));
            }
        }

        public ZombieStateEnum ZombieState { get; private set; }

        public void Die()
        {
            State = AttackStateEnum.InActive;
            deathStartTime = innerClock;
        }
        public void Explode()
        {
            State = AttackStateEnum.InActive;
            ZombieState = ZombieStateEnum.Exploded;
            deathStartTime = innerClock;
        }
        public void Slowed()
        {
            ZombieState = ZombieStateEnum.Slowed;
        }

        public override void TimeChanged()
        {
            if (deathStartTime != 0 && ZombieState == ZombieStateEnum.Exploded && innerClock - deathStartTime == 19)
            {
                State = AttackStateEnum.Dead;
            }
            else if (deathStartTime != 0 && innerClock - deathStartTime == 38)
            {
                State = AttackStateEnum.Dead;
            }
            else
            {
                base.TimeChanged();
            }
            
        }

        public override void DamagedBy(OffensiveItem attacker)
        {
            this.HP -= attacker.Damage;
            if (HP <= 0)
            {
                State = AttackStateEnum.InActive;
                Die();
            }
        }
        public override void Move()
        {
            if (ZombieState==ZombieStateEnum.Slowed)
            {
                placeX += speed/2;
            }
            else
            {
                base.Move();
            }
           
        }

    }
}
