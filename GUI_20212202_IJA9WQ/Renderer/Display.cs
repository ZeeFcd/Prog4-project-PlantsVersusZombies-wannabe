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
        GeometryCalculator geometryCalculator;
        double areaWidth;
        double areaHeight;
        public void SetupLogic(IGameLogic logic)
        {
            this.logic = logic;
        }
        public void SetupCoordinateCalculator(GeometryCalculator geometryCalculator)
        {
            this.geometryCalculator = geometryCalculator;
        }
        public void Resize(double areaWidth, double areaHeight)
        {
            this.areaWidth = areaWidth;
            this.areaHeight = areaHeight;
            
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (logic != null)
            {
                drawingContext.DrawRectangle(GameBrushes.BackgroundDayBrush, null, new Rect(0, 0, areaWidth, areaHeight));
                int leftShopBorder = (int)Math.Round(0.01 * areaWidth);
                int rightShopBorder = (int)Math.Round(0.11 * areaWidth);
                int upperShopBorder = (int)Math.Round(0.02 * areaHeight);
                int lowerShopBorder = (int)Math.Round(0.83 * areaHeight);
                drawingContext.DrawRectangle(GameBrushes.ItemShopBrush, null, new Rect(leftShopBorder, upperShopBorder, rightShopBorder- leftShopBorder, lowerShopBorder- upperShopBorder));

                for (int i = 0; i < logic.PlantsSelectionDay.Length; i++)
                {
                    drawingContext.DrawRectangle(logic.PlantsSelectionDay[i].ShopImageBrush, new Pen(Brushes.Black, 1), new Rect(0.03* areaWidth, 0.02* areaHeight + (i * 0.11* areaHeight)+ upperShopBorder, 0.058* areaWidth, 0.09* areaHeight));
                }
                
                foreach (var item in logic.LawnMovers)
                {
                    drawingContext.DrawGeometry(GameBrushes.LawnMoverBrush, new Pen(Brushes.Black,1), item.Area);
                }

                foreach (var item in logic.Zombies)
                {
                    drawingContext.DrawGeometry(GameBrushes.ZombieBrush, new Pen(Brushes.Black, 1), item.Area);
                }

                foreach (var item in logic.Plants)
                {
                    drawingContext.DrawGeometry(item.GameImageBrush, new Pen(Brushes.Black, 1), item.Area);
                }
                
            }
        }

    }
}
