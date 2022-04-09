using GUI_20212202_IJA9WQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_IJA9WQ.Logic
{
    public class GameLogic : IGameLogic
    {


        public List<Plant> Plants { get; set; }
        public Plant[] PlantsSelectionDay { get; }
        public Plant CurrentlySelected { get; set; }
        public List<Zombie> Zombies { get; set; }
        public List<LawnMover> LawnMovers { get; set; }

        public GameLogic(int areaWidth, int areaHeight)
        {
            Plants = new List<Plant>();
            Zombies = new List<Zombie>();
            LawnMovers = new List<LawnMover>();

            for (int i = 1; i < 6; i++)
            {
                LawnMovers.Add(new LawnMover(190, 75 + (99 * i) - 50, 75, 53, 10));
            }

            PlantsSelectionDay = new Plant[] { new Peashooter(), new Sunflower(), new Peashooter(), new Sunflower(), new Peashooter(), new Sunflower() };
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
        }

        public void PlantSelect(int i)
        {
            CurrentlySelected = PlantsSelectionDay[i];
        }

        public void PlantToPlant(int i, int j)
        {
            CurrentlySelected.CenterX = i;
            CurrentlySelected.CenterY = j;
            Plants.Add(CurrentlySelected.GetCopy());
            CurrentlySelected = null;
        }

    }
}

