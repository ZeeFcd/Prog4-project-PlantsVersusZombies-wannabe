using GUI_20212202_IJA9WQ.Models;
using System.Collections.Generic;

namespace GUI_20212202_IJA9WQ.Logic
{
    public interface IGameLogic
    {
        object View { get; set; }
        Plant CurrentlySelected { get; set; }
        List<LawnMover> LawnMovers { get; set; }
        List<Plant> Plants { get; set; }
        Plant[] PlantsSelectionDay { get; }
        List<Zombie> Zombies { get; set; }

        void PlantSelect(int i);
        void PlantToPlant(int i, int j,int x, int y);
        void TimeStep();
        void ChangeView(string view);
    }
}