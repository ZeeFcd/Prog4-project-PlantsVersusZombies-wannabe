using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GUI_20212202_IJA9WQ.Assets
{
    static class GameBrushes
    {
        public static readonly Brush BackgroundDayBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "background_day.png"), UriKind.RelativeOrAbsolute)));     
        public static readonly Brush LawnMoverBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "lawn_mover.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush ItemShopBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "itemShop1.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush PeashooterBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "peashooter.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush SunflowerBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "sunflower.png"), UriKind.RelativeOrAbsolute)));
       
    }
}
