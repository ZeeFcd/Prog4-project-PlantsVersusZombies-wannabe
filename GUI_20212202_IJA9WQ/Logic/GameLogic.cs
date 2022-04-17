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
            // ideiglenes plant windth height
            int plantWidth= (int)Math.Round(0.06 * areaWidth);
            int plantHeight = (int)Math.Round(0.1 * areaHeight);
            PlantsSelectionDay = new Plant[] { new Peashooter(plantWidth, plantHeight), new Sunflower(plantWidth, plantHeight), new Peashooter(plantWidth, plantHeight), new Sunflower(plantWidth, plantHeight), new Sunflower(plantWidth, plantHeight), new Sunflower(plantWidth, plantHeight) };
            for (int i = 1; i < 6; i++)
            {
                LawnMovers.Add(new LawnMover(190, 75 + (99 * i) - 60, 75, 53, 20));
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
                int j = (zombie.PlaceX - 260) / temp;
                int temp2 = (int)(490 / 5);
                int i = ((zombie.PlaceY - 75) / temp2);
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


        public void NewSize(int newAreaWidth, int newAreaHeight) 
        {
            int plantWidth = (int)Math.Round(0.06 * newAreaWidth);
            int plantHeight = (int)Math.Round(0.1 * newAreaHeight);
            int plantX = (int)Math.Round(0.06 * newAreaWidth);
            int plantY = (int)Math.Round(0.1 * newAreaHeight);
            foreach (var item in Plants)
            {
                item.DisplayWidth = plantWidth;
                item.DisplayHeight = plantHeight;
                
            }

        }
    }
}

