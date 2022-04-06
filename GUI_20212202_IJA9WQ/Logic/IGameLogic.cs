using GUI_20212202_IJA9WQ.Models;
using System.Collections.Generic;

namespace GUI_20212202_IJA9WQ.Logic
{
    public interface IGameLogic
    {
        List<LawnMover> LawnMovers { get; set; }
        List<Plant> Plants { get; set; }
        List<Zombie> Zombies { get; set; }

        void TimeStep();
    }
}