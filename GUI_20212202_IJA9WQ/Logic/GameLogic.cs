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
        int currentlySelectedIndex;
        bool shovelSelected;
        int waveCount;
        public Action ZombieBiteSound;
        public Action ShootSound;
        public Action SnowShootSound;
        public Action ZombiesStartedSound;
        public Action WaveSound;
        public Action SunCollectedSound;
        public Action ZombieGroanSound;
        public Action BulletHitSound;
        public Action ShovelSound;
        public Action PlantSelectedSound;
        public Action PotatoMineExploisonSound;
        public Action PlantPlacedSound;
        public Action LawMoverSound;
        public Action HugeWaveSound;
        public Action ZombieGulpSound;
        public Action CherrybombSound;
        public Action ScreamSound;

        public Action GameOver;
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
        public int CurrentlySelectedIndex { get => currentlySelectedIndex; }
        public int SunValue { get => sunValue; }
        public bool ShovelSelected { get => shovelSelected; }
        public int WaveCount { get => waveCount;  }

        public GameLogic(CoordinateCalculator coordinateCalculator)
        {
            this.coordinateCalculator = coordinateCalculator;
            currentlySelectedIndex = -1;
            Plants = new List<Plant>();
            Zombies = new List<Zombie>();
            Bullets = new List<Bullet>();
            LawnMovers = new LawnMover[5];
            Suns = new List<Sun>();
            gameClock = 0;
            waveCount = 0;

            sunValue = 50;
            PlantsMatrix = new Plant[5, 9];
            ZombiesMatrix = new List<Zombie>[5, 9];
            ZombiesMatrixInitialize();

            Plant peashooter = new Peashooter(coordinateCalculator.PlantWidth, coordinateCalculator.PlantHeight);
            Plant sunflower = new Sunflower(coordinateCalculator.PlantWidth, coordinateCalculator.PlantHeight);
            Plant cherrybomb = new CherryBomb(coordinateCalculator.PlantWidth, coordinateCalculator.PlantHeight);
            Plant wallNut = new WallNut(coordinateCalculator.PlantWidth, coordinateCalculator.PlantHeight);
            Plant potatoMine = new PotatoMine(coordinateCalculator.PlantWidth, coordinateCalculator.PlantHeight);
            Plant snowPea = new SnowPea(coordinateCalculator.PlantWidth, coordinateCalculator.PlantHeight);

            peashooter.AbilityEvent += ShooterShoot;
            sunflower.AbilityEvent += SunFlowerProduce;
            cherrybomb.AbilityEvent += CherryBombExplode;
            potatoMine.AbilityEvent += PotatoMineExplode;
            snowPea.AbilityEvent += ShooterShoot;

            PlantsSelectionDay = new Plant[] { peashooter, sunflower, cherrybomb, wallNut, potatoMine, snowPea };

            for (int i = 0; i < 5; i++)
            {
                LawnMovers[i] = new LawnMover(coordinateCalculator.LawMoverStartX,
                    coordinateCalculator.LawMoverStartYShift + coordinateCalculator.LawMoverStartY * (i + 1),
                    coordinateCalculator.LawMoverWidth,
                    coordinateCalculator.LawMoverHeight,
                    coordinateCalculator.LawMoverSpeed);
            }

        }

        public void TimeStep()
        {
            if (gameClock>= 500)
            {
                if (gameClock == 500)
                {
                    ZombiesStartedSound?.Invoke();
                    Zombies.Add(new Zombie(coordinateCalculator.ZombieStartX,
                     coordinateCalculator.ZombieStartYShift + coordinateCalculator.ZombieStartY * RandomGenerator.Rand.Next(1, 6),
                     coordinateCalculator.ZombieWidth,
                     coordinateCalculator.ZombieHeight,
                     coordinateCalculator.ZombieSpeed,
                     1,
                     10));
                }
                else if (gameClock % 750 == 0)
                {
                    for (int i = 0; i < waveCount+1; i++)
                    {
                        SmallWave();
                    }
                }
                else if (gameClock % 1125 == 0)
                {
                        MediumWave(); 
                }
                else if (gameClock %1875 == 0)
                {
                    HugeWaveSound?.Invoke();
                }
                else if (gameClock % 1925 == 0)
                {
                    SmallWave();
                    WaveSound?.Invoke();
                }
                else if (gameClock % 1975 == 0)
                {
                    MediumWave();
                }
                else if (gameClock % 2025 == 0)
                {
                    MediumWave();
                    waveCount++;
                }

            }

            SunMoving();
            if (gameClock != 0 && gameClock % 85 == 0)
            {
                int cellX = RandomGenerator.Rand.Next(0, PlantsMatrix.GetLength(1));
                int cellY = RandomGenerator.Rand.Next(0, PlantsMatrix.GetLength(0));
                double x = coordinateCalculator.LeftMapBorder + cellX * coordinateCalculator.GameMapCellWidth;
                double y = coordinateCalculator.UpperMapBorder + cellY * coordinateCalculator.GameMapCellHeight + coordinateCalculator.PlantHeight * 0.5;
                Suns.Add(new Sun(x, y,
                    coordinateCalculator.SunWidth,
                    coordinateCalculator.SunHeight,
                    coordinateCalculator.SunSpeed(x, y)
            ));
            }

            for (int i = 0; i < LawnMovers.Length; i++)
            {
                LawMoverStep(i);
            }

            foreach (var bullet in Bullets)
            {
               BulletStep(bullet);
            }

            foreach (var zombie in Zombies)
            {
                ZombieStep(zombie);
            }

            foreach (var plant in Plants)
            {
                plant.Ability();
            }
   
            foreach (var plant in PlantsSelectionDay)
            {
                plant.TimeChanged();
            }
           
            ZombieTimeChanged();
            PlantsTimeChanged();
            BulletTimeChanged();

            gameClock += 1;
        }
        private void ZombiesMatrixInitialize()
        {
            for (int i = 0; i < ZombiesMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < ZombiesMatrix.GetLength(1); j++)
                {
                    ZombiesMatrix[i, j] = new List<Zombie>();
                }
            }
        }
        private void PlantsTimeChanged() 
        {
            List<Plant> deadplants = new List<Plant>();
            foreach (var plant in Plants)
            {
                if (plant.State == AttackStateEnum.Dead)
                {
                    deadplants.Add(plant);
                }
                else
                {
                    plant.TimeChanged();
                }

            }
            foreach (var deadplant in deadplants)
            {
                PlantTerminated(deadplant);
                if (deadplant.Type!=PlantEnum.Cherrybomb && deadplant.Type != PlantEnum.Potatomine)
                {
                    ZombieGulpSound?.Invoke();
                }
                
            }

        }
        private void ZombieTimeChanged()
        {
            List<Zombie> deadzombies = new List<Zombie>();
            foreach (var zombie in Zombies)
            {
                if (zombie.State == AttackStateEnum.Dead)
                {
                    deadzombies.Add(zombie);
                }
                else
                {
                    zombie.TimeChanged();
                }

            }
            foreach (var deadzombie in deadzombies)
            {
                ZombieTerminated(deadzombie);
            }
        }
        private void BulletTimeChanged() 
        {
            List<Bullet> deadbullets = new List<Bullet>();
            foreach (var bullet in Bullets)
            {
                if (bullet.State == AttackStateEnum.Dead)
                {
                    deadbullets.Add(bullet);
                }
                else
                {
                    bullet.TimeChanged();
                }

            }
            foreach (var deadbullet in deadbullets)
            {
                Bullets.Remove(deadbullet);
            }
        }
        private void LawMoverStart(int i)
        {
            if (!LawnMovers[i].IsStarted)
            {
                LawnMovers[i].IsStarted = true;
                LawMoverSound?.Invoke();
            }
        }
        public void PlantSelect(int i)
        {
            shovelSelected = false;
            if (PlantsSelectionDay[i].Ispurchaseable && sunValue>= PlantsSelectionDay[i].Price)
            {
                currentlySelectedIndex = i;
                PlantSelectedSound?.Invoke();
            }

        }
        public void ShovelSelect()
        {

            currentlySelectedIndex = -1;
            shovelSelected = true;
        }
        public void PlantDelete(int j, int i)
        {
            Plants.Remove(PlantsMatrix[i, j]);
            PlantsMatrix[i, j] = null;
            shovelSelected = false;
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
            (int, int) cellindexes = coordinateCalculator.WhichCellInGameMap(offensiveItem.PlaceX, offensiveItem.PlaceY);
            int n = cellindexes.Item1;
            while (n < ZombiesMatrix.GetLength(1) && ZombiesMatrix[cellindexes.Item2, n].Count == 0)
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
                PlantsSelectionDay[currentlySelectedIndex].Buy();
                (double, double) plantGameCoords = coordinateCalculator.WhichCoordinateInGameMapPlant(j, i);
                Plant plantToplace = PlantsSelectionDay[currentlySelectedIndex].GetCopy();
                plantToplace.PlaceX = plantGameCoords.Item1;
                plantToplace.PlaceY = plantGameCoords.Item2;
                Plants.Add(plantToplace);
                PlantsMatrix[i, j] = plantToplace;
                sunValue -= PlantsSelectionDay[currentlySelectedIndex].Price;
                currentlySelectedIndex = -1;
                PlantPlacedSound?.Invoke();
            }
        }
        private void ZombieStep(Zombie zombie)
        {
            if (zombie.PlaceX < coordinateCalculator.LeftMapBorder)
            {
                if (LawnMovers[zombie.PlaceGameMatrixY] != null)
                {
                    LawMoverStart(zombie.PlaceGameMatrixY);
                }
                else
                {
                    Gameover();
                }
            }
            else
            {
                if (zombie.State!=AttackStateEnum.Dead && zombie.State != AttackStateEnum.InActive)
                {
                    int firstplantXindex = 0;
                    if (coordinateCalculator.IsInGameMap(zombie.PlaceX + coordinateCalculator.ZombieWidth / 2, zombie.PlaceY + coordinateCalculator.ZombieHeight / 2))
                    {
                        firstplantXindex = FirstPlantInSameRow(zombie);
                        if (firstplantXindex > -1)
                        {
                            if (!zombie.IsCollision(PlantsMatrix[zombie.PlaceGameMatrixY, firstplantXindex]) || PlantsMatrix[zombie.PlaceGameMatrixY, firstplantXindex].State == AttackStateEnum.InActive|| PlantsMatrix[zombie.PlaceGameMatrixY, firstplantXindex].State == AttackStateEnum.Attack)
                            {
                                zombie.State = AttackStateEnum.Normal;
                                zombie.Move();
                                PlaceZombieInGameMatrix(zombie);
                            }
                            else
                            {

                                zombie.State = AttackStateEnum.Attack;
                                PlantsMatrix[zombie.PlaceGameMatrixY, firstplantXindex].DamagedBy(zombie);
                                if (gameClock%35==0)
                                {
                                    ZombieBiteSound?.Invoke();
                                }
                                ;// ATTACK THE PLANT
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
        }
        private void LawMoverStep(int i)
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
                                zombie.Die();

                            }
                        }
                        if (firstzombieindex<8)
                        {
                            foreach (var zombie in ZombiesMatrix[i, firstzombieindex+1])
                            {
                                if (LawnMovers[i].IsCollision(zombie))
                                {
                                    zombie.Die();
                                }
                            }
                        }
                    }
                }
            }

        }
        public void IsSunSelected(double x, double y)
        {
            bool isclicked = false;
            foreach (var sun in Suns)
            {
                isclicked=sun.IsInSun(x, y);
                if (isclicked)
                {
                    SunCollectedSound?.Invoke();
                }
            }
        }
        private void SunMoving()
        {
            List<Sun> sunstoremove = new List<Sun>();
            foreach (var sun in Suns)
            {
                if (sun.Ismoving)
                {
                    bool stopCondition = coordinateCalculator.IsSunReachedShop(sun.PlaceX, sun.PlaceY);
                    if (stopCondition)
                    {
                        sunValue += 25;
                        sunstoremove.Add(sun);
                    }
                    else
                    {
                        sun.Move(stopCondition);
                    }
                }

            }
            for (int k = 0; k < sunstoremove.Count; k++)
            {
                Suns.Remove(sunstoremove[k]);
            }
        }
        private void ShooterShoot(Plant plant) 
        {
            if (IsZombieInSameRow(plant) > -1)
            {
                (int, int) cellindexes = coordinateCalculator.WhichCellInGameMap(plant.PlaceX + plant.DisplayWidth / 2, plant.PlaceY + plant.DisplayHeight / 2);
                Bullets.Add(new Bullet(
                                 coordinateCalculator.BulletX + cellindexes.Item1 * coordinateCalculator.GameMapCellWidth,
                                 coordinateCalculator.BulletY + cellindexes.Item2 * coordinateCalculator.GameMapCellHeight,
                                 coordinateCalculator.BulletWidth,
                                 coordinateCalculator.BulletHeight,
                                 coordinateCalculator.BulletSpeed,
                                 plant.Hasfrozenbullet,
                                 plant.Damage
                                 ));
                if (plant.Hasfrozenbullet)
                {
                    SnowShootSound?.Invoke();
                }
                else
                {
                    ShootSound?.Invoke();
                } 
            }
        }
        private void SunFlowerProduce(Plant plant)
        {
            (int, int) cellindexes = coordinateCalculator.WhichCellInGameMap(plant.PlaceX + plant.DisplayWidth / 2, plant.PlaceY + plant.DisplayHeight / 2);
            double x = coordinateCalculator.LeftMapBorder + cellindexes.Item1 * coordinateCalculator.GameMapCellWidth;
            double y = coordinateCalculator.UpperMapBorder + cellindexes.Item2 * coordinateCalculator.GameMapCellHeight+ plant.DisplayHeight* 0.5;
            Suns.Add(new Sun(x,y,
              coordinateCalculator.SunWidth,
              coordinateCalculator.SunHeight,
              coordinateCalculator.SunSpeed(x, y)
              ));

        }
        private void CherryBombExplode(Plant plant)
        {
            (int, int) cellindexes = coordinateCalculator.WhichCellInGameMap(plant.PlaceX + plant.DisplayWidth / 2, plant.PlaceY + plant.DisplayHeight / 2);

            for (int i = cellindexes.Item2-1; i < cellindexes.Item2 +2; i++)
            {
                for (int j = cellindexes.Item1 - 1; j < cellindexes.Item1 + 2; j++)
                {
                    if (!(j < 0 || j > PlantsMatrix.GetLength(1) - 1 || i < 0 || i > PlantsMatrix.GetLength(0) - 1))
                    {
                        ZombiesMatrix[i, j].ForEach(x => x.Explode());
                    }
                }
            }
            CherrybombSound?.Invoke();
        }
        private void PlantTerminated(GameItem gameitem) 
        {
            Plant plant = gameitem as Plant;
            (int, int) cellindexes = coordinateCalculator.WhichCellInGameMap(plant.PlaceX + plant.DisplayWidth / 2, plant.PlaceY + plant.DisplayHeight / 2);
            Plants.Remove(plant);
            PlantsMatrix[cellindexes.Item2, cellindexes.Item1] = null;
        }
        private void ZombieTerminated(Zombie zombie) 
        {
            Zombies.Remove(zombie);
            ZombiesMatrix[zombie.PlaceGameMatrixY, zombie.PlaceGameMatrixX].Remove(zombie);
        }
        private void PotatoMineExplode(Plant plant)
        {
            (int, int) cellindexes = coordinateCalculator.WhichCellInGameMap(plant.PlaceX + plant.DisplayWidth / 2, plant.PlaceY + plant.DisplayHeight / 2);
            if (cellindexes.Item1!=8)
            {
                foreach (var zombie in ZombiesMatrix[cellindexes.Item2, cellindexes.Item1])
                {
                    zombie.Explode();
                }
                foreach (var zombie in ZombiesMatrix[cellindexes.Item2, cellindexes.Item1+1])
                {
                    if (zombie.PlaceX- (plant.PlaceX+plant.DisplayWidth/3)<plant.DisplayWidth/8)
                    {
                        zombie.Explode();
                    } 
                }   
            }
            else
            {
                foreach (var zombie in ZombiesMatrix[cellindexes.Item2, cellindexes.Item1])
                {
                    zombie.Explode();
                }
            }
            PotatoMineExploisonSound?.Invoke();
        }
        private void BulletStep(Bullet bullet)
        {
            if (bullet.State != AttackStateEnum.InActive && bullet.State != AttackStateEnum.Dead)
            {
                if (bullet.PlaceX > coordinateCalculator.DisplayWidth + coordinateCalculator.BulletWidth)
                {
                    bullet.State = AttackStateEnum.Dead;
                }
                else 
                {
                    bullet.Move();
                    (int, int) cellindexes = coordinateCalculator.WhichCellInGameMap(bullet.PlaceX, bullet.PlaceY);
                    int firstzombieindex = IsZombieInSameRow(bullet);
                    if (firstzombieindex > -1)
                    {
                        Zombie closest = ZombiesMatrix[cellindexes.Item2, firstzombieindex].First();
                        bool foundCollision = false;
                        foreach (var zombie in ZombiesMatrix[cellindexes.Item2, firstzombieindex])
                        {
                            if (bullet.IsCollision(zombie))
                            {
                                foundCollision = true;
                                if (zombie.PlaceX - bullet.PlaceX < closest.PlaceX - bullet.PlaceX)
                                {
                                    closest = zombie;
                                }
                            }
                        }
                        if (foundCollision&& closest.State!=AttackStateEnum.InActive)
                        {
                            if (bullet.IsFrozen)
                            {
                                closest.Slowed();
                                closest.DamagedBy(bullet);
                                bullet.Hit();
                                BulletHitSound?.Invoke();
                            }
                            else
                            {
                                closest.DamagedBy(bullet);
                                bullet.Hit();
                                BulletHitSound?.Invoke();
                            }
                        }
                    }
                }
            }
 
        }
        private void Gameover() 
        {
            GameOver?.Invoke();
        }
        private void SmallWave()
        {
            int random = RandomGenerator.Rand.Next(2 + waveCount, 3 + waveCount);
            //int brokenzombie = RandomGenerator.Rand.Next(1 t, 5 + waveCount);
            for (int i = 0; i < 2; i++)
            {

                Zombies.Add(new Zombie(coordinateCalculator.ZombieStartX,
             coordinateCalculator.ZombieStartYShift + coordinateCalculator.ZombieStartY * RandomGenerator.Rand.Next(1, 6),
             coordinateCalculator.ZombieWidth,
             coordinateCalculator.ZombieHeight,
             coordinateCalculator.ZombieSpeed+waveCount* coordinateCalculator.ZombieSpeed * 0.5,
             1+ waveCount*0.5,
             12 + waveCount*3
             ));;
            }
        }
        private void MediumWave()
        {
            int random = RandomGenerator.Rand.Next(3 + waveCount, 5 + waveCount);
            int brokenzombie = RandomGenerator.Rand.Next(3 + waveCount, 5 + waveCount);

            for (int i = 0; i < random; i++)
            {
                Zombies.Add(new Zombie(coordinateCalculator.ZombieStartX,
             coordinateCalculator.ZombieStartYShift + coordinateCalculator.ZombieStartY * RandomGenerator.Rand.Next(1, 6),
             coordinateCalculator.ZombieWidth,
             coordinateCalculator.ZombieHeight,
             coordinateCalculator.ZombieSpeed + waveCount * coordinateCalculator.ZombieSpeed*0.5,
             1 + waveCount * 0.5,
             12 + waveCount*3
             ));
            }
        }
        
        
    }
}

