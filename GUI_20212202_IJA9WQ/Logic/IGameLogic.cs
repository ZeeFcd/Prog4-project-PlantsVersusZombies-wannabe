﻿using GUI_20212202_IJA9WQ.Models;
using System.Collections.Generic;

namespace GUI_20212202_IJA9WQ.Logic
{
    public interface IGameLogic
    {
        Plant CurrentlySelected { get; }
        List<LawnMover> LawnMovers { get; }

        int GameClock { get; }
        List<Plant> Plants { get; }
        Plant[] PlantsSelectionDay { get; }
        List<Zombie> Zombies { get;  }
        List<Bullet> Bullets { get; }
        List<Sun> Suns { get;  }

        void PlantSelect(int i);
        void PlantToPlant(int j, int i);
        void TimeStep();
    }
}