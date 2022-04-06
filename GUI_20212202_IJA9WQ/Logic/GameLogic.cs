using GUI_20212202_IJA9WQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_IJA9WQ.Logic
{
    public class GameLogic : IGameLogic
    {
        public List<Plant> Plants { get; set; }
        public List<Zombie> Zombies { get; set; }
        public List<LawnMover> LawnMovers { get; set; }

        public GameLogic(int areaWidth, int areaHeight)
        {
            Plants = new List<Plant>();
            Zombies = new List<Zombie>();
            LawnMovers = new List<LawnMover>();

            for (int i = 0; i < 5; i++)
            {
                LawnMovers.Add(new LawnMover(areaWidth + 100, areaHeight + 100, areaWidth, areaHeight));
            }
        }

        public void TimeStep()
        {


        }



    }
}
