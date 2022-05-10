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
        double mouseX;
        double mouseY;

        public void SetupBrushes(GameAnimationBrushes brushes)
        {
            this.brushes = brushes;
        }
        public void SetupLogic(IGameLogic logic)
        {
            this.logic = logic;
        }
        public void SetMouse(double x, double y) 
        {
            mouseX = x;
            mouseY = y;
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

                drawingContext.DrawRectangle(GameBrushes.ShovelBrush,null,
                    new Rect(
                        coordinateCalculator.ShovelX,
                        coordinateCalculator.ShovelY,
                        coordinateCalculator.ShovelWidth,
                        coordinateCalculator.ShovelHeight
                        ));

                var text = new FormattedText(
                    logic.SunValue.ToString(), System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface(new FontFamily("Arial"), FontStyles.Normal, FontWeights.ExtraBold, FontStretches.Normal),
                   coordinateCalculator.DisplayHeight*0.023, Brushes.Black,10);
                
                var origin = new Point(coordinateCalculator.SunCounterX,coordinateCalculator.SunCounterY);
                drawingContext.DrawText(text,origin);

                for (int i = 0; i < logic.PlantsSelectionDay.Length; i++)
                {
                    bool notenoughmoney = logic.SunValue < logic.PlantsSelectionDay[i].Price;
                    Pen pen = null;
                    Brush plantitembrush = null;
                    if (logic.PlantsSelectionDay[i].Ispurchaseable)
                    {
                        pen = new Pen(Brushes.Black, 1);
                    }
                    else
                    {
                        pen = new Pen(Brushes.Red, 5);
                    }
                    switch (logic.PlantsSelectionDay[i].Type)
                    {
                        case PlantEnum.Peashooter:
                            if (notenoughmoney)
                            {
                                plantitembrush = GameBrushes.Dea_PeashooterItemBrush;
                            }
                            else
                            {
                                plantitembrush = GameBrushes.PeashooterItemBrush;
                            }
                            break;
                        case PlantEnum.Wallnut:
                            if (notenoughmoney)
                            {
                                plantitembrush = GameBrushes.Dea_WallnutItemBrush;
                            }
                            else
                            {
                                plantitembrush = GameBrushes.WallnutItemBrush;
                            }
                            break;
                        case PlantEnum.Potatomine:
                            if (notenoughmoney)
                            {
                                plantitembrush = GameBrushes.Dea_PotatoMineItemBrush;
                            }
                            else
                            {
                                plantitembrush = GameBrushes.PotatoMineItemBrush;
                            }
                            break;
                        case PlantEnum.Snowpeashooter:
                            if (notenoughmoney)
                            {
                                plantitembrush = GameBrushes.Dea_SnowPeaItemBrush;
                            }
                            else
                            {
                                plantitembrush = GameBrushes.SnowPeaItemBrush;
                            }
                            break;
                        case PlantEnum.Cherrybomb:
                            if (notenoughmoney)
                            {
                                plantitembrush = GameBrushes.Dea_CherryBombItemBrush;
                            }
                            else
                            {
                                plantitembrush = GameBrushes.CherryBombItemBrush;
                            }
                            break;
                        case PlantEnum.Sunflower:
                            if (notenoughmoney)
                            {
                                plantitembrush = GameBrushes.Dea_SunflowerItemBrush;
                            }
                            else
                            {
                                plantitembrush = GameBrushes.SunflowerItemBrush;
                            }
                            break;
                    }
                    drawingContext.DrawRectangle(plantitembrush, pen,
                                  new Rect(
                                      coordinateCalculator.ShopItemPlaceX,
                                      i * coordinateCalculator.ShopItemPlaceY + coordinateCalculator.ShopItemYShift,
                                      coordinateCalculator.ShopItemWidth,
                                      coordinateCalculator.ShopItemHeight));
                }

                if (logic.CurrentlySelectedIndex != -1 && coordinateCalculator.IsInGameMap(mouseX, mouseY))
                {
                    (int, int) gameCellindexes = coordinateCalculator.WhichCellInGameMap(mouseX, mouseY);
                    (double, double) plantGameCoords = coordinateCalculator.WhichCoordinateInGameMapPlant(gameCellindexes.Item1, gameCellindexes.Item2);
                    drawingContext.PushOpacity(0.5);
                    Geometry showcase= new RectangleGeometry(new Rect(plantGameCoords.Item1, plantGameCoords.Item2, coordinateCalculator.PlantWidth, coordinateCalculator.PlantHeight));
                    switch (logic.PlantsSelectionDay[logic.CurrentlySelectedIndex].Type)
                    {
                        case PlantEnum.Peashooter:
                            drawingContext.DrawGeometry(GameBrushes.PeashooterBrush, null, showcase);
                            break;
                        case PlantEnum.Wallnut:
                            drawingContext.DrawGeometry(GameBrushes.WallnutBrush, null, showcase);
                            break;
                        case PlantEnum.Potatomine:
                            drawingContext.DrawGeometry(GameBrushes.PotatomineBrush, null, showcase);
                            break;
                        case PlantEnum.Snowpeashooter:
                            drawingContext.DrawGeometry(GameBrushes.SnowPeashooterBrush, null, showcase);
                            break;
                        case PlantEnum.Cherrybomb:
                            drawingContext.DrawGeometry(GameBrushes.CherryBrush, null, showcase);
                            break;
                        case PlantEnum.Sunflower:
                            drawingContext.DrawGeometry(GameBrushes.SunflowerBrush, null, showcase);
                            break;
                     
                    }
                    drawingContext.Pop();
                }

                foreach (var plant in logic.Plants)
                {
                    switch (plant.Type)
                    {
                        case PlantEnum.Peashooter:
                            drawingContext.DrawGeometry(brushes.PeashooterGIF[plant.InnerClock % brushes.PeashooterGIF.Count],null /*new Pen(Brushes.Black, 1)*/, plant.Area);
                            break;
                        case PlantEnum.Wallnut:
                            drawingContext.DrawGeometry(brushes.WallnutGIF[plant.InnerClock % brushes.WallnutGIF.Count], null /*new Pen(Brushes.Black, 1)*/, plant.Area);
                            break;                           
                          
                        case PlantEnum.Snowpeashooter:
                            drawingContext.DrawGeometry(brushes.SnowpeashooterGIF[plant.InnerClock % brushes.SnowpeashooterGIF.Count], null /*new Pen(Brushes.Black, 1)*/, plant.Area);
                            break;
                       
                        case PlantEnum.Sunflower:
                            drawingContext.DrawGeometry(brushes.SunfloowerGIF[plant.InnerClock % brushes.SunfloowerGIF.Count], null /*new Pen(Brushes.Black, 1)*/, plant.Area);
                            break;
                    }
                }

                foreach (var zombie in logic.Zombies)
                {
                    if (zombie.State == AttackStateEnum.Attack)
                    {
                        drawingContext.DrawGeometry(brushes.ZombieEatGIF[zombie.InnerClock % brushes.ZombieEatGIF.Count], null /*new Pen(Brushes.Black, 1)*/, zombie.Area);
                    }
                    else if (zombie.State == AttackStateEnum.InActive)
                    {
                        if (zombie.ZombieState==ZombieStateEnum.Exploded)
                        {
                            drawingContext.DrawGeometry(brushes.ZombieAshGIF[(zombie.InnerClock-zombie.DeathStartTime) % brushes.ZombieAshGIF.Count], null /*new Pen(Brushes.Black, 1)*/, zombie.Area);
                        }
                        else
                        {
                            var shiftX = coordinateCalculator.ZombieWidth*0.15;
                            var shiftY = coordinateCalculator.GameMapCellHeight*0.07;
                            Geometry dead = new RectangleGeometry(
                                    new Rect(zombie.PlaceX - shiftX, zombie.PlaceY - shiftY , coordinateCalculator.ZombieWidth + shiftX, coordinateCalculator.ZombieHeight + shiftY));
                            drawingContext.DrawGeometry(brushes.ZombieDeathGIF[(zombie.InnerClock - zombie.DeathStartTime) % brushes.ZombieDeathGIF.Count], null /*new Pen(Brushes.Black, 1)*/, dead);
                        }
                    }
                    else if (zombie.State == AttackStateEnum.Normal)
                    {
                        drawingContext.DrawGeometry(brushes.ZombieWalkGIF[zombie.InnerClock % brushes.ZombieWalkGIF.Count], null /*new Pen(Brushes.Black, 1)*/, zombie.Area);
                    }
                    
                }

                foreach (var lawnMover in logic.LawnMovers)
                {
                    if (lawnMover != null)
                    {
                        drawingContext.DrawGeometry(GameBrushes.LawnMoverBrush, null /*new Pen(Brushes.Black, 1)*/, lawnMover.Area);
                    }
                }

                foreach (var bullet in logic.Bullets)
                {
                    if (bullet.IsFrozen)
                    {
                        if (bullet.State == AttackStateEnum.InActive || bullet.State == AttackStateEnum.Dead)
                        {
                            drawingContext.DrawGeometry(GameBrushes.FrozenSplashBrush, null /*new Pen(Brushes.Black, 1)*/, bullet.Area);
                        }
                        else
                        {
                            drawingContext.DrawGeometry(GameBrushes.SnowPeaBrush, null /*new Pen(Brushes.Black, 1)*/, bullet.Area);
                        }
                        
                    }
                    else
                    {
                        if (bullet.State == AttackStateEnum.InActive|| bullet.State == AttackStateEnum.Dead)
                        {
                            drawingContext.DrawGeometry(GameBrushes.SplashBrush, null /*new Pen(Brushes.Black, 1)*/, bullet.Area);
                        }
                        else
                        {
                            drawingContext.DrawGeometry(GameBrushes.PeaBrush, null /*new Pen(Brushes.Black, 1)*/, bullet.Area);
                        }
                        
                    }
                    
                }
                foreach (var plant in logic.Plants)
                {
                    switch (plant.Type)
                    {
                        case PlantEnum.Potatomine:
                            if (plant.State == AttackStateEnum.InActive)
                            {
                                drawingContext.DrawGeometry(GameBrushes.InActivePotatoMineBrush, null, plant.Area);
                            }
                            else if (plant.State == AttackStateEnum.Normal)
                            {
                                drawingContext.DrawGeometry(brushes.PotatomineGIF[plant.InnerClock % brushes.PotatomineGIF.Count], null /*new Pen(Brushes.Black, 1)*/, plant.Area);
                            }
                            else
                            {
                                var shiftX = coordinateCalculator.GameMapCellWidth * 0.2;
                                var shiftY = coordinateCalculator.GameMapCellHeight * 0.17;
                                Geometry explosion = new RectangleGeometry(
                                    new Rect(plant.PlaceX - shiftX, plant.PlaceY, coordinateCalculator.GameMapCellWidth + shiftX, coordinateCalculator.GameMapCellHeight - shiftY));
                                drawingContext.DrawGeometry(GameBrushes.PotatoMineExplodedBrush, null, explosion);
                            }
                            break;
                     
                        case PlantEnum.Cherrybomb:
                            if (plant.State == AttackStateEnum.Normal)
                            {
                                drawingContext.DrawGeometry(brushes.CherryGIF[(plant.InnerClock - plant.DeathStartTime) % brushes.CherryGIF.Count], null /*new Pen(Brushes.Black, 1)*/, plant.Area);
                            }
                            else
                            {
                                var shiftX = coordinateCalculator.GameMapCellWidth;
                                var shiftY = coordinateCalculator.GameMapCellHeight;
                                Geometry explosion = new RectangleGeometry(
                                    new Rect(plant.PlaceX - shiftX, plant.PlaceY - shiftY - 0.2 * coordinateCalculator.GameMapCellHeight, coordinateCalculator.GameMapCellWidth + 2 * shiftX, coordinateCalculator.GameMapCellHeight + 2 * shiftY));
                                drawingContext.DrawGeometry(brushes.PowieGIF[plant.InnerClock % brushes.PowieGIF.Count], null /*new Pen(Brushes.Black, 1)*/, explosion);
                            }
                            break;
                        
                    }
                }

                foreach (var sun in logic.Suns)
                {
                    drawingContext.DrawGeometry(GameBrushes.SunBrush, null /*new Pen(Brushes.Black, 1)*/, sun.Area);
                }

                if (logic.ShovelSelected)
                {
                    Geometry shovel = new RectangleGeometry(
                                   new Rect(mouseX - coordinateCalculator.PlantWidth / 2, mouseY - coordinateCalculator.PlantHeight / 2, coordinateCalculator.PlantWidth,coordinateCalculator.PlantHeight));
                    drawingContext.DrawGeometry(GameBrushes.ShovelSelectedBrush, null /*new Pen(Brushes.Black, 1)*/, shovel);
                }
                else if (logic.CurrentlySelectedIndex>-1)
                {
                    Geometry plant = new RectangleGeometry(
                                  new Rect(mouseX - coordinateCalculator.PlantWidth / 2, mouseY - coordinateCalculator.PlantHeight / 2, coordinateCalculator.PlantWidth, coordinateCalculator.PlantHeight));
                    switch (logic.PlantsSelectionDay[logic.CurrentlySelectedIndex].Type)
                    {
                        case PlantEnum.Peashooter:
                            drawingContext.DrawGeometry(GameBrushes.PeashooterBrush, null /*new Pen(Brushes.Black, 1)*/, plant);
                            break;
                        case PlantEnum.Wallnut:
                            drawingContext.DrawGeometry(GameBrushes.WallnutBrush, null /*new Pen(Brushes.Black, 1)*/, plant);
                            break;
                        case PlantEnum.Potatomine:
                            drawingContext.DrawGeometry(GameBrushes.PotatomineBrush, null /*new Pen(Brushes.Black, 1)*/, plant);
                            break;
                        case PlantEnum.Snowpeashooter:
                            drawingContext.DrawGeometry(GameBrushes.SnowPeashooterBrush, null /*new Pen(Brushes.Black, 1)*/, plant);
                            break;
                        case PlantEnum.Cherrybomb:
                            drawingContext.DrawGeometry(GameBrushes.CherryBrush, null /*new Pen(Brushes.Black, 1)*/, plant);
                            break;
                        case PlantEnum.Sunflower:
                            drawingContext.DrawGeometry(GameBrushes.SunflowerBrush, null /*new Pen(Brushes.Black, 1)*/, plant);
                            break;
                    }
                    
                }
                if (logic.GameEnded)
                {
                    Geometry died = new RectangleGeometry(
                        new Rect(
                            coordinateCalculator.LeftMapBorder,
                            coordinateCalculator.UpperMapBorder,
                            7*coordinateCalculator.GameMapCellWidth,
                            4*coordinateCalculator.GameMapCellHeight));
                    drawingContext.DrawGeometry(GameBrushes.DiedBrush, null, died);
                }
               
            }
        }
    }
}
