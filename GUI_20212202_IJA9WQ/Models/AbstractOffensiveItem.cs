using GUI_20212202_IJA9WQ.Assets;

namespace GUI_20212202_IJA9WQ.Models
{
    public abstract class OffensiveItem : GameItem
    {
        protected StateEnum State { get; set; }
        public int Damage { get; set; }
        public int HP { get; set; }

        public void DamagedBy(OffensiveItem attacker)
        {
            this.HP -= attacker.Damage;
            if (HP < 1)
            {
                Terminated();
            }
        }

    }
}
