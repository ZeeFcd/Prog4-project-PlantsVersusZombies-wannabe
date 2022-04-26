using GUI_20212202_IJA9WQ.Models;
using GUI_20212202_IJA9WQ.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI_20212202_IJA9WQ.Helpers;

namespace GUI_20212202_IJA9WQ.Logic
{
    public class GameLogic : IGameLogic
    {
        CoordinateCalculator coordinateCalculator;
        int gameClock;
        int sunValue;
        private Plant[,] PlantsMatrix;
        private List<Zombie>[,] ZombiesMatrix;
        public List<Plant> Plants { get; set; }
        public List<Zombie> Zombies { get; set; }
        public List<Bullet> Bullets { get; set; }
        public List<LawnMover> LawnMovers { get; set; }
        public List<Sun> Suns { get; set; }
        public Plant[] PlantsSelectionDay { get; }
        public Plant CurrentlySelected { get; set; }
        
        public GameLogic(CoordinateCalculator coordinateCalculator)
        {
            this.coordinateCalculator = coordinateCalculator;
            Plants = new List<Plant>();
            Zombies = new List<Zombie>();
            Bullets = new List<Bullet>();
            LawnMovers = new List<LawnMover>();
            Suns = new List<Sun>();
            gameClock = 0;
            sunValue=50;
            PlantsMatrix = new Plant[5,9];
            ZombiesMatrix = new List<Zombie>[5, 9];
            ZombiesMatrixInitialize();
            
            PlantsSelectionDay = new Plant[] { 
                new Peashooter(coordinateCalculator.PlantWidth, coordinateCalculator.PlantHeight),
                new Sunflower(coordinateCalculator.PlantWidth, coordinateCalculator.PlantHeight),
                new Peashooter(coordinateCalculator.PlantWidth, coordinateCalculator.PlantHeight),
                new Sunflower(coordinateCalculator.PlantWidth, coordinateCalculator.PlantHeight),
                new Sunflower(coordinateCalculator.PlantWidth, coordinateCalculator.PlantHeight),
                new Sunflower(coordinateCalculator.PlantWidth, coordinateCalculator.PlantHeight) };

            for (int i = 1; i < 6; i++)
            {
                LawnMovers.Add(new LawnMover(190, 75 + (99 * i) - 60, coordinateCalculator.LawMoverWidth, coordinateCalculator.LawMoverHeight, 20));
            }

            for (int i = 1; i < 6; i++)
            {
                
                Zombies.Add(new Zombie(1050, 75 + (99 * i) -103, coordinateCalculator.ZombieWidth, coordinateCalculator.ZombieHeight, -0.4));
            }

        }

        public void TimeStep()
        {

            //for (int i = 0; i < LawnMovers.Count; i++)
            //{
            //   LawnMovers[i].Move();
            //}
            
            //foreach (var zombie in Zombies)
            //{
            //    int firstplantXindex = FirstPlantInSameRow(zombie);
            //    if (260 < zombie.PlaceX && zombie.PlaceX < 970 && 75 < zombie.PlaceY && zombie.PlaceY < 565 && firstplantXindex > -1)
            //    {
            //        if (!zombie.IsCollision(PlantsMatrix[zombie.PlaceGameMatrixY, firstplantXindex]))
            //        {
            //            zombie.Move();
            //            PlaceZombieInGamematrix(zombie);
            //        }  
            //    }
            //    else
            //    {
            //        zombie.Move();
            //        PlaceZombieInGamematrix(zombie);
            //    }
            //}
            //if (gameClock%170==0)
            //{
            //    ;
            //}

            //gameClock += 1;
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
        private int FirstPlantInSameRow(Zombie zombie) 
        {
            int n = zombie.PlaceGameMatrixX;
            while (n>=0 && PlantsMatrix[zombie.PlaceGameMatrixY,n]==null)
            {
                n--;
            }
            if ( n >= 0)
            {
                return n;
            }
            return -1;

        }
        private void PlaceZombieInGamematrix(Zombie zombie) 
        {
            if (260 < zombie.PlaceX && zombie.PlaceX < 970 && 75 < zombie.PlaceY && zombie.PlaceY < 565)
            {
                int oldJ = zombie.PlaceGameMatrixX;
                int oldI = zombie.PlaceGameMatrixY;
                int temp = (int)(715 / 9);
                int j = (int)((zombie.PlaceX - 260) / temp);
                int temp2 = (int)(490 / 5);
                int i = (int)((zombie.PlaceY - 75) / temp2);
                zombie.PlaceGameMatrixX = j;
                zombie.PlaceGameMatrixY = i;

                if (oldJ>-1)
                {
                    if (j!=oldJ)
                    {
                        ZombiesMatrix[i, oldJ].Remove(zombie);
                        ZombiesMatrix[i, j].Add(zombie);
                        ;
                    }
                }                   
            }
        }

        public void PlantToPlant(int j, int i)
        {
            if (PlantsMatrix[i,j]==null)
            {
                (double, double) plantGameCoords = coordinateCalculator.WhichCoordinateInGameMapPlant(j, i);
                CurrentlySelected.PlaceX = plantGameCoords.Item1;
                CurrentlySelected.PlaceY = plantGameCoords.Item2;
                Plants.Add(CurrentlySelected.GetCopy());
                PlantsMatrix[i, j] = CurrentlySelected.GetCopy();
                CurrentlySelected = null;
            }
            
        }
    }
}

