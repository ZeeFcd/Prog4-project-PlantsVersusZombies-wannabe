using GUI_20212202_IJA9WQ.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GUI_20212202_IJA9WQ.Renderer
{
    public class Display : FrameworkElement
    {
        IGameLogic logic;
        Size area;
        public void SetupLogic(IGameLogic logic)
        {
            this.logic = logic;
        }

        public void SetupSizes(Size area)
        {
            this.area = area;
            this.InvalidateVisual();
        }

        public Brush BackgroundDayBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "background_day.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush LawnMoverBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "lawn_mover.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (logic != null)
            {
                drawingContext.DrawRectangle(BackgroundDayBrush, null, new Rect(0, 0, area.Width, area.Height));
                //drawingContext.DrawGeometry(Brushes.Black, null, logic.);
                //drawingContext.DrawGeometry(Brushes.White, new Pen(Brushes.Red, 2), logic.Letter.Area);
                foreach (var item in logic.LawnMovers)
                {
                    drawingContext.DrawGeometry(LawnMoverBrush, null, item.Area);
                }
            }
        }
    }
}
