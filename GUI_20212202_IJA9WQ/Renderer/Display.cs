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
            if (logic != null )
            {
                drawingContext.DrawRectangle(GameBrushes.BackgroundDayBrush, null,
                    new Rect(0, 0,coordinateCalculator.DisplayWidth, coordinateCalculator.DisplayHeight));
                
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
                    20, Brushes.Black,10);

                var origin = new Point(coordinateCalculator.SunCounterX,coordinateCalculator.SunCounterY);
                drawingContext.DrawText(text,origin);
                    
                   

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
                    drawingContext.DrawGeometry(plant.GameImageBrush, new Pen(Brushes.Black, 1), plant.Area);
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
