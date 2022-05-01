﻿using GUI_20212202_IJA9WQ.Models;
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
        public int GameClock { get { return gameClock; } }

        int sunValue;
        private Plant[,] PlantsMatrix;
        private List<Zombie>[,] ZombiesMatrix;
        public List<Plant> Plants { get; }
        public List<Zombie> Zombies { get; }
        public List<Bullet> Bullets { get; }
        public LawnMover[] LawnMovers { get; }
        public List<Sun> Suns { get; }
        public Plant[] PlantsSelectionDay { get; }
        public Plant CurrentlySelected { get; set; }
        public int SunValue { get => sunValue; }

        public GameLogic(CoordinateCalculator coordinateCalculator)
        {
            this.coordinateCalculator = coordinateCalculator;
            Plants = new List<Plant>();
            Zombies = new List<Zombie>();
            Bullets = new List<Bullet>();
            LawnMovers = new LawnMover[5];
            Suns = new List<Sun>();
            gameClock = 0;
            
            sunValue = 50;
            PlantsMatrix = new Plant[5, 9];
            ZombiesMatrix = new List<Zombie>[5, 9];
            ZombiesMatrixInitialize();

            PlantsSelectionDay = new Plant[] {
                new Peashooter(coordinateCalculator.PlantWidth, coordinateCalculator.PlantHeight),
                new Sunflower(coordinateCalculator.PlantWidth, coordinateCalculator.PlantHeight),
                new CherryBomb(coordinateCalculator.PlantWidth, coordinateCalculator.PlantHeight),
                new WallNut(coordinateCalculator.PlantWidth, coordinateCalculator.PlantHeight),
                new PotatoMine(coordinateCalculator.PlantWidth, coordinateCalculator.PlantHeight),
                new SnowPea(coordinateCalculator.PlantWidth, coordinateCalculator.PlantHeight)
            };


            for (int i = 0; i < 5; i++)
            {
                LawnMovers[i]=new LawnMover(coordinateCalculator.LawMoverStartX,
                    coordinateCalculator.LawMoverStartYShift + coordinateCalculator.LawMoverStartY * (i+1),
                    coordinateCalculator.LawMoverWidth,
                    coordinateCalculator.LawMoverHeight,
                    coordinateCalculator.LawMoverSpeed);
            }

            for (int i = 1; i < 6; i++)
            {
                if (i%2==1)
                {
                    Zombies.Add(new Zombie(coordinateCalculator.ZombieStartX,
                    coordinateCalculator.ZombieStartYShift + coordinateCalculator.ZombieStartY * i,
                    coordinateCalculator.ZombieWidth,
                    coordinateCalculator.ZombieHeight,
                    coordinateCalculator.ZombieSpeed));
                }
                
            }

        }

        public void TimeStep()
        {
            for (int i = 0; i < LawnMovers.Length; i++)
            {
                LawMoverStep(i);
            }

            foreach (var bullet in Bullets)
            {
                bullet.Move();
            }

            foreach (var zombie in Zombies)
            {
                ZombieTimeStep(zombie);
            }

            foreach (var plant in Plants)
            {
                if (gameClock % 45 == 0)
                {
                    if (plant.Type == PlantEnum.Peashooter)
                    {
                        ShootTimeStep(plant);
                    }
                    else if (plant.Type == PlantEnum.Snowpeashooter)
                    {
                        ShootTimeStep(plant);
                    }
                }
            }

            List<Sun> sunstoremove = new List<Sun>();
            foreach (var sun in Suns)
            {
                if (coordinateCalculator.IsSunReachedShop(sun.PlaceX, sun.PlaceY))
                {
                    sunValue += 25;
                    sunstoremove.Add(sun);
                }
                else
                {
                    sun.Move(coordinateCalculator.IsSunReachedShop(sun.PlaceX, sun.PlaceY));
                }
                
            }
            for (int k = 0; k < sunstoremove.Count; k++)
            {
                Suns.Remove(sunstoremove[k]);
            }
            



            if (gameClock == 50)
            {
                Zombies.Add(new Zombie(coordinateCalculator.ZombieStartX,
                   coordinateCalculator.ZombieStartYShift + coordinateCalculator.ZombieStartY * RandomGenerator.Rand.Next(1, 6),
                   coordinateCalculator.ZombieWidth,
                   coordinateCalculator.ZombieHeight,
                   coordinateCalculator.ZombieSpeed)); ;

                Suns.Add(new Sun(coordinateCalculator.LeftMapBorder,
              coordinateCalculator.UpperMapBorder,
              coordinateCalculator.SunWidth,
              coordinateCalculator.SunHeight,
              coordinateCalculator.SunSpeed(coordinateCalculator.LeftMapBorder, coordinateCalculator.UpperMapBorder)
              ));
            }
            if (gameClock == 100)
            {
                Zombies.Add(new Zombie(coordinateCalculator.ZombieStartX,
                   coordinateCalculator.ZombieStartYShift + coordinateCalculator.ZombieStartY * RandomGenerator.Rand.Next(1, 6),
                   coordinateCalculator.ZombieWidth,
                   coordinateCalculator.ZombieHeight,
                   coordinateCalculator.ZombieSpeed)); ;
                Zombies.Add(new Zombie(coordinateCalculator.ZombieStartX,
                   coordinateCalculator.ZombieStartYShift + coordinateCalculator.ZombieStartY * RandomGenerator.Rand.Next(1, 6),
                   coordinateCalculator.ZombieWidth,
                   coordinateCalculator.ZombieHeight,
                   coordinateCalculator.ZombieSpeed));
                Suns.Add(new Sun(coordinateCalculator.LeftMapBorder + 3 * coordinateCalculator.GameMapCellWidth,
              coordinateCalculator.UpperMapBorder + 3 * coordinateCalculator.GameMapCellHeight,
              coordinateCalculator.SunWidth,
              coordinateCalculator.SunHeight,
              coordinateCalculator.SunSpeed(
                  coordinateCalculator.LeftMapBorder + 3 * coordinateCalculator.GameMapCellWidth,
                  coordinateCalculator.UpperMapBorder + 3 * coordinateCalculator.GameMapCellHeight)
              ));
            }
            if (gameClock == 110)
            {
                Zombies.Add(new Zombie(coordinateCalculator.ZombieStartX,
                   coordinateCalculator.ZombieStartYShift + coordinateCalculator.ZombieStartY * RandomGenerator.Rand.Next(1, 6),
                   coordinateCalculator.ZombieWidth,
                   coordinateCalculator.ZombieHeight,
                   coordinateCalculator.ZombieSpeed)); ;
                Zombies.Add(new Zombie(coordinateCalculator.ZombieStartX,
                   coordinateCalculator.ZombieStartYShift + coordinateCalculator.ZombieStartY * RandomGenerator.Rand.Next(1, 6),
                   coordinateCalculator.ZombieWidth,
                   coordinateCalculator.ZombieHeight,
                   coordinateCalculator.ZombieSpeed));

                Suns.Add(new Sun(coordinateCalculator.LeftMapBorder + 4 * coordinateCalculator.GameMapCellWidth,
                    coordinateCalculator.UpperMapBorder + 5 * coordinateCalculator.GameMapCellHeight,
                    coordinateCalculator.SunWidth,
                    coordinateCalculator.SunHeight,
                    coordinateCalculator.SunSpeed(
                        coordinateCalculator.LeftMapBorder + 4 * coordinateCalculator.GameMapCellWidth,
                         coordinateCalculator.UpperMapBorder + 5 * coordinateCalculator.GameMapCellHeight)
                    ));
            }
            if (gameClock == 150)
            {
                Zombies.Add(new Zombie(coordinateCalculator.ZombieStartX,
                   coordinateCalculator.ZombieStartYShift + coordinateCalculator.ZombieStartY * RandomGenerator.Rand.Next(1, 6),
                   coordinateCalculator.ZombieWidth,
                   coordinateCalculator.ZombieHeight,
                   coordinateCalculator.ZombieSpeed));
                Suns.Add(new Sun(coordinateCalculator.LeftMapBorder + 7 * coordinateCalculator.GameMapCellWidth,
               coordinateCalculator.UpperMapBorder + 4 * coordinateCalculator.GameMapCellHeight,
               coordinateCalculator.SunWidth,
               coordinateCalculator.SunHeight,
               coordinateCalculator.SunSpeed(
                  coordinateCalculator.LeftMapBorder + 7 * coordinateCalculator.GameMapCellWidth,
                  coordinateCalculator.UpperMapBorder + 4 * coordinateCalculator.GameMapCellHeight)
               ));
            }


           
            foreach (var plant in Plants)
            {
                plant.TimeChanged();
            }
            foreach (var zombie in Zombies)
            {
                zombie.TimeChanged();
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
        
        public void LawMoverStart(int i)
        {
            LawnMovers[i].IsStarted = true;
                        
        }

        public void PlantSelect(int i)
        {
            CurrentlySelected = PlantsSelectionDay[i];
        }
        private int FirstPlantInSameRow(Zombie zombie)
        {
            int n = zombie.PlaceGameMatrixX;
            while (n >= 0 && PlantsMatrix[zombie.PlaceGameMatrixY, n] == null)
            {
                n--;
            }
            if (n >= 0)
            {
                return n;
            }
            return -1;
        }

        private int IsZombieInSameRow(OffensiveItem offensiveItem)
        {
            (int, int) coordinates = coordinateCalculator.WhichCellInGameMap(offensiveItem.PlaceX, offensiveItem.PlaceY);
            int n = coordinates.Item1;
            while (n < ZombiesMatrix.GetLength(1) && ZombiesMatrix[coordinates.Item2, n].Count == 0)
            {
                n++;
            }
            if (n < ZombiesMatrix.GetLength(1))
            {
                return n;
            }
            return -1;
        }

        private void PlaceZombieInGameMatrix(Zombie zombie)
        {
            if (coordinateCalculator.IsInGameMap(zombie.PlaceX + coordinateCalculator.ZombieWidth / 2, zombie.PlaceY + coordinateCalculator.ZombieHeight / 2))
            {
                int oldJ = zombie.PlaceGameMatrixX;
                (int, int) actualCellIndexes = coordinateCalculator.WhichCellInGameMap(
                    zombie.PlaceX + coordinateCalculator.ZombieWidth / 2,
                    zombie.PlaceY + coordinateCalculator.ZombieHeight / 2);

                zombie.PlaceGameMatrixX = actualCellIndexes.Item1;
                zombie.PlaceGameMatrixY = actualCellIndexes.Item2;

                if (oldJ > -1)
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
            if (PlantsMatrix[i, j] == null)
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
            if (zombie.PlaceX<coordinateCalculator.LeftMapBorder)
            {
                if (LawnMovers[zombie.PlaceGameMatrixY]!=null)
                {
                    LawMoverStart(zombie.PlaceGameMatrixY);
                }
                else
                {
                    ;//játék vége
                }
            }
            else
            {
                int firstplantXindex = 0;
                if (coordinateCalculator.IsInGameMap(zombie.PlaceX + coordinateCalculator.ZombieWidth / 2, zombie.PlaceY + coordinateCalculator.ZombieHeight / 2))
                {
                    firstplantXindex = FirstPlantInSameRow(zombie);
                    if (firstplantXindex > -1)
                    {
                        if (!zombie.IsCollision(PlantsMatrix[zombie.PlaceGameMatrixY, firstplantXindex]))
                        {
                            zombie.State = AttackStateEnum.Normal;
                            zombie.Move();
                            PlaceZombieInGameMatrix(zombie);
                        }
                        else
                        {
                            zombie.State = AttackStateEnum.Attack;
                            ;//to be continued, ATTACK THE PLANT
                        }
                    }
                    else
                    {
                        zombie.State = AttackStateEnum.Normal;
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
        public void LawMoverStep(int i)
        {
            if (LawnMovers[i] != null && LawnMovers[i].IsStarted)
            {
                if (LawnMovers[i].PlaceX > coordinateCalculator.DisplayWidth + coordinateCalculator.LawMoverWidth)
                {
                    LawnMovers[i] = null;
                }
                else
                {
                    LawnMovers[i].Move();
                    int firstzombieindex = IsZombieInSameRow(LawnMovers[i]);
                    if (firstzombieindex > -1)
                    {
                        List<Zombie> diedzombies = new List<Zombie>();
                        foreach (var zombie in ZombiesMatrix[i, firstzombieindex])
                        {
                            if (LawnMovers[i].IsCollision(zombie))
                            {
                                diedzombies.Add(zombie);

                                Zombies.Remove(zombie);

                            }
                        }
                        for (int k = 0; k < diedzombies.Count; k++)
                        {
                            ZombiesMatrix[i, firstzombieindex].Remove(diedzombies[k]);
                        }
                    }
                }

            }

        }
        private void ShootTimeStep(Plant plant)
        {
            if (IsZombieInSameRow(plant)>-1)
            {
                (int, int) coordinates = coordinateCalculator.WhichCellInGameMap(plant.PlaceX+plant.DisplayWidth/2, plant.PlaceY+plant.DisplayHeight/2);
                if (plant.Type == PlantEnum.Peashooter)
                {
                    Bullets.Add(new Bullet(
                                        coordinateCalculator.BulletX + coordinates.Item1 * coordinateCalculator.GameMapCellWidth,
                                        coordinateCalculator.BulletY + coordinates.Item2 * coordinateCalculator.GameMapCellHeight,
                                        coordinateCalculator.BulletWidth,
                                        coordinateCalculator.BulletHeight,
                                        coordinateCalculator.BulletSpeed,
                                        false,
                                        plant.Damage
                                   ));
                }
                else if (plant.Type == PlantEnum.Snowpeashooter)
                {
                    Bullets.Add(new Bullet(
                                        coordinateCalculator.BulletX + coordinates.Item1 * coordinateCalculator.GameMapCellWidth,
                                        coordinateCalculator.BulletY + coordinates.Item2 * coordinateCalculator.GameMapCellHeight,
                                        coordinateCalculator.BulletWidth,
                                        coordinateCalculator.BulletHeight,
                                        coordinateCalculator.BulletSpeed,
                                        true,
                                        plant.Damage
                                   )); 
                }

            }
        }
    }
}

