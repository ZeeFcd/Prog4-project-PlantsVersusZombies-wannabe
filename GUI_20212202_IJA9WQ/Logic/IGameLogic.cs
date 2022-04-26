using GUI_20212202_IJA9WQ.Models;
using System.Collections.Generic;

namespace GUI_20212202_IJA9WQ.Logic
{
    public interface IGameLogic
    {
        Plant CurrentlySelected { get; set; }
        List<LawnMover> LawnMovers { get; set; }
        List<Plant> Plants { get; set; }
        Plant[] PlantsSelectionDay { get; }
        List<Zombie> Zombies { get; set; }

        void PlantSelect(int i);
        void PlantToPlant(int j, int i);
        void TimeStep();
    }
}