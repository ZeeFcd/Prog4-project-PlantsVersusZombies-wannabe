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
                LawnMovers.Add(new LawnMover(coordinateCalculator.LawMoverStartX,
                    coordinateCalculator.LawMoverStartYShift + coordinateCalculator.LawMoverStartY * i,
                    coordinateCalculator.LawMoverWidth,
                    coordinateCalculator.LawMoverHeight,
                    coordinateCalculator.LawMoverSpeed));
            }

            for (int i = 1; i < 6; i++)
            {
                Zombies.Add(new Zombie(coordinateCalculator.ZombieStartX,
                    coordinateCalculator.ZombieStartYShift+coordinateCalculator.ZombieStartY * i, 
                    coordinateCalculator.ZombieWidth,
                    coordinateCalculator.ZombieHeight,
                    coordinateCalculator.ZombieSpeed));
            }

        }

        public void TimeStep()
        {
            //for (int i = 0; i < LawnMovers.Count; i++)
            //{
            //    LawnMovers[i].Move();
            //}

            foreach (var zombie in Zombies)
            {
                ZombieTimeStep(zombie);
                
            }
            if (gameClock > 1000 )
            {
                ;
            }

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
        private void PlaceZombieInGameMatrix(Zombie zombie) 
        {
            if (coordinateCalculator.IsInGameMap(zombie.PlaceX+coordinateCalculator.ZombieWidth/2,zombie.PlaceY+coordinateCalculator.ZombieHeight/2))
            {
                int oldJ = zombie.PlaceGameMatrixX;
                (int,int) actualCellIndexes=coordinateCalculator.WhichCellInGameMap(
                    zombie.PlaceX+coordinateCalculator.ZombieWidth/2,
                    zombie.PlaceY+coordinateCalculator.ZombieHeight/2);
                
                zombie.PlaceGameMatrixX = actualCellIndexes.Item1;
                zombie.PlaceGameMatrixY = actualCellIndexes.Item2;

                if (oldJ>-1)
                {
                    if (zombie.PlaceGameMatrixX != oldJ)
                    {
                        ZombiesMatrix[zombie.PlaceGameMatrixY, oldJ].Remove(zombie);
                        ZombiesMatrix[zombie.PlaceGameMatrixY, zombie.PlaceGameMatrixX].Add(zombie);
                    }
                }
                else
                {
                    ZombiesMatrix[zombie.PlaceGameMatrixY, zombie.PlaceGameMatrixX].Add(zombie);
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

        private void ZombieTimeStep(Zombie zombie) 
        {
            int firstplantXindex = 0;
            if (coordinateCalculator.IsInGameMap(zombie.PlaceX + coordinateCalculator.ZombieWidth / 2, zombie.PlaceY + coordinateCalculator.ZombieHeight / 2))
            {
                firstplantXindex = FirstPlantInSameRow(zombie);
                if (firstplantXindex > -1)
                {
                    if (!zombie.IsCollision(PlantsMatrix[zombie.PlaceGameMatrixY, firstplantXindex]))
                    {
                        zombie.Move();
                        PlaceZombieInGameMatrix(zombie);
                    }
                    else
                    {
                        ;//to be continued, ATTACK THE PLANT
                    }
                }
                else
                {
                    zombie.Move();
                    PlaceZombieInGameMatrix(zombie);
                }
            }
            else
            {
                zombie.Move();
                PlaceZombieInGameMatrix(zombie);
            }

        }
    }
}

