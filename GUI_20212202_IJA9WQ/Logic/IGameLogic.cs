using GUI_20212202_IJA9WQ.Models;
using System.Collections.Generic;

namespace GUI_20212202_IJA9WQ.Logic
{
    public interface IGameLogic
    {
        List<Bullet> Bullets { get; }
        Plant CurrentlySelected { get; set; }
        int GameClock { get; }
        List<LawnMover> LawnMovers { get; }
        List<Plant> Plants { get; }
        Plant[] PlantsSelectionDay { get; }
        List<Sun> Suns { get; }
        List<Zombie> Zombies { get; }

        void PlantSelect(int i);
        void PlantToPlant(int j, int i);
        void TimeStep();
    }
}