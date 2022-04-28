using GUI_20212202_IJA9WQ.Logic;
using GUI_20212202_IJA9WQ.Assets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GUI_20212202_IJA9WQ.Helpers;

namespace GUI_20212202_IJA9WQ.Renderer
{
    public class Display : FrameworkElement
    {
        IGameLogic logic;
        CoordinateCalculator coordinateCalculator;
        GameAnimationBrushes brushes;

        public void SetupBrushes(GameAnimationBrushes brushes)
        {
            this.brushes = brushes;
        }
        public void SetupLogic(IGameLogic logic)
        {
            this.logic = logic;
        }
        public void SetupCoordinateCalculator(CoordinateCalculator coordinateCalculator)
        {
            this.coordinateCalculator = coordinateCalculator;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (logic != null)
            {
                drawingContext.DrawRectangle(GameBrushes.BackgroundDayBrush, null,
                    new Rect(0, 0, coordinateCalculator.DisplayWidth, coordinateCalculator.DisplayHeight));

                drawingContext.DrawRectangle(GameBrushes.ItemShopBrush, null,
                    new Rect(
                    coordinateCalculator.LeftShopBorder,
                    coordinateCalculator.UpperShopBorder,
                    coordinateCalculator.RightShopBorder - coordinateCalculator.LeftShopBorder,
                    coordinateCalculator.LowerShopBorderFull - coordinateCalculator.UpperShopBorder));

                for (int i = 0; i < logic.PlantsSelectionDay.Length; i++)
                {
                    drawingContext.DrawRectangle(logic.PlantsSelectionDay[i].ShopImageBrush, new Pen(Brushes.Black, 1),
                        new Rect(
                            coordinateCalculator.ShopItemPlaceX,
                            i * coordinateCalculator.ShopItemPlaceY + coordinateCalculator.ShopItemYShift,
                            coordinateCalculator.ShopItemWidth,
                            coordinateCalculator.ShopItemHeight));
                }

                foreach (var plant in logic.Plants)
                {
                    switch (plant.Type)
                    {
                        case PlantEnum.Peashooter:
                            drawingContext.DrawGeometry(brushes.PeashooterGIF[logic.GameClock%brushes.PeashooterGIF.Count], new Pen(Brushes.Black, 1), plant.Area);
                            break;
                        case PlantEnum.Wallnut:
                            break;
                        case PlantEnum.Potatomine:
                            break;
                        case PlantEnum.Snowpeashooter:
                            break;
                        case PlantEnum.Cherrybomb:
                            break;
                        case PlantEnum.Sunflower:
                            drawingContext.DrawGeometry(brushes.SunfloowerGIF[logic.GameClock % brushes.SunfloowerGIF.Count], new Pen(Brushes.Black, 1), plant.Area);
                            break;
                        default:
                            break;
                    }
                    
                }

                foreach (var zombie in logic.Zombies)
                {
                    drawingContext.DrawGeometry(GameBrushes.ZombieBrush, new Pen(Brushes.Black, 1), zombie.Area);
                }

                foreach (var lawnMover in logic.LawnMovers)
                {
                    drawingContext.DrawGeometry(GameBrushes.LawnMoverBrush, new Pen(Brushes.Black, 1), lawnMover.Area);
                }

                foreach (var bullet in logic.Bullets)
                {
                    drawingContext.DrawGeometry(GameBrushes.PeaBrush, new Pen(Brushes.Black, 1), bullet.Area);
                }

                foreach (var sun in logic.Suns)
                {
                    drawingContext.DrawGeometry(GameBrushes.SunBrush, new Pen(Brushes.Black, 1), sun.Area);
                }

            }
        }

    }
}
