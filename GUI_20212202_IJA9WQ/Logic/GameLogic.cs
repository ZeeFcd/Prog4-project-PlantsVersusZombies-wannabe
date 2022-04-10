using GUI_20212202_IJA9WQ.Models;
using GUI_20212202_IJA9WQ.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_IJA9WQ.Logic
{
    public class GameLogic : IGameLogic
    {
        int gameClock;
        int sunValue;
        private Plant[,] PlantsMatrix;
        private List<Zombie>[,] ZombiesMatrix;
        public List<Plant> Plants { get; set; }
        public List<Zombie> Zombies { get; set; }
        public List<LawnMover> LawnMovers { get; set; }
        public Plant[] PlantsSelectionDay { get; }
        public Plant CurrentlySelected { get; set; }
        
        public GameLogic(int areaWidth, int areaHeight)
        {
            Plants = new List<Plant>();
            Zombies = new List<Zombie>();
            LawnMovers = new List<LawnMover>();
            gameClock = 0;
            sunValue=50;
            PlantsMatrix = new Plant[5,9];
            ZombiesMatrix = new List<Zombie>[5, 9];
            ZombiesMatrixInitialize();
            PlantsSelectionDay = new Plant[] { new Peashooter(), new Sunflower(), new Peashooter(), new Sunflower(), new Peashooter(), new Sunflower() };
            for (int i = 1; i < 6; i++)
            {
                LawnMovers.Add(new LawnMover(190, 75 + (99 * i) - 60, 75, 53, 10));
            }

            for (int i = 1; i < 6; i++)
            {
                
                Zombies.Add(new Zombie(1050, 75 + (99 * i) -103, 75, 101, -0.4f));
            }

        }

        public void TimeStep()
        {

            //for (int i = 0; i < LawnMovers.Count; i++)
            //{
            //    bool outside = LawnMovers[i].Move();
            //    if (outside)
            //    {
            //        LawnMovers.RemoveAt(i);
            //    }
            //}

            //foreach (var zombie in Zombies)
            //{
            //    zombie.Move();
            //}

            gameClock += 1;
        }

        public void ZombiesMatrixInitialize()
        {
            for (int i = 0; i < ZombiesMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < ZombiesMatrix.GetLength(1); j++)
                {
                    ZombiesMatrix[i, j] = new List<Zombie>();
                }
            }
        }

        public void PlantSelect(int i)
        {
            CurrentlySelected = PlantsSelectionDay[i];
        }

        public void PlantToPlant(int j, int i,int x, int y)
        {
            if (PlantsMatrix[i,j]==null)
            {
                CurrentlySelected.PlaceX = x;
                CurrentlySelected.PlaceY = y;
                Plants.Add(CurrentlySelected.GetCopy());
                PlantsMatrix[i, j] = CurrentlySelected.GetCopy();
                CurrentlySelected = null;
            }
            
        }

    }
}

