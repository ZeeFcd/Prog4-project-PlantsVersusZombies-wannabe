using GUI_20212202_IJA9WQ.Models;
using System.Collections.Generic;

namespace GUI_20212202_IJA9WQ.Logic
{
    public interface IGameLogic
    {
        int SunValue { get; }
        int CurrentlySelectedIndex { get; }
        LawnMover[] LawnMovers { get; }
        bool ShovelSelected { get; }
        bool GameEnded { get; }

        int GameClock { get; }
        List<Plant> Plants { get; }
        Plant[] PlantsSelectionDay { get; }
        List<Zombie> Zombies { get;  }
        List<Bullet> Bullets { get; }
        List<Sun> Suns { get;  }

        void PlantSelect(int i);
        void ShovelSelect();
        void PlantToPlant(int j, int i);
        void TimeStep();
    }
}