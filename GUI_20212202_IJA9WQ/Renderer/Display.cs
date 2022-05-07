using GUI_20212202_IJA9WQ.Assets;
using GUI_20212202_IJA9WQ.Logic;
using System.Windows;
using System.Windows.Media;

namespace GUI_20212202_IJA9WQ.Renderer
{
    public class Display : FrameworkElement
    {
        IGameLogic logic;
        public void SetupLogic(IGameLogic logic)
        {
            this.logic = logic;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (logic != null)
            {
                drawingContext.DrawRectangle(GameBrushes.BackgroundDayBrush, null, new Rect(0, 0, 1025, 600));
                drawingContext.DrawRectangle(GameBrushes.ItemShopBrush, null, new Rect(10, 10, 104, 495));

                for (int i = 0; i < logic.PlantsSelectionDay.Length; i++)
                {
                    drawingContext.DrawRectangle(logic.PlantsSelectionDay[i].ShopImageBrush, new Pen(Brushes.Black, 1), new Rect(30, 25 + (i * 65), 60, 60));
                }

                foreach (var item in logic.LawnMovers)
                {
                    drawingContext.DrawGeometry(GameBrushes.LawnMoverBrush, new Pen(Brushes.Black, 1), item.Area);
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
