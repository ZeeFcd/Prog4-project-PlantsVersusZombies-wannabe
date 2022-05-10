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
        public static readonly Brush ItemShopBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "itemShop.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush SunBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "sun1.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush PeaBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "pea.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush SnowPeaBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "snowpea.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush CherryBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "cherrybomb.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush PowieBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "powie.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush InActivePotatoMineBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "hole.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush PotatoMineExplodedBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "exploded.png"), UriKind.RelativeOrAbsolute)));
        
        public static readonly Brush ShovelSelectedBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "shovelitem.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush PeashooterBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "peashooter.gif"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush SnowPeashooterBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "snowpeashooter.gif"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush SunflowerBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "sunflower.gif"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush PotatomineBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "potatomine.gif"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush WallnutBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "wallnut.gif"), UriKind.RelativeOrAbsolute)));

        public static readonly Brush FrozenSplashBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "splashblue.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush SplashBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "splashgreen.png"), UriKind.RelativeOrAbsolute)));

        public static readonly Brush SunflowerItemBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "sunflowerItem.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush PeashooterItemBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "peashooterItem.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush WallnutItemBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "wallnutItem.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush CherryBombItemBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "cherrybombItem.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush SnowPeaItemBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "snowpeashooterItem.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush PotatoMineItemBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "potatomineItem.png"), UriKind.RelativeOrAbsolute)));

        public static readonly Brush Dea_SunflowerItemBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "dea_sunflowerItem.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush Dea_PeashooterItemBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "dea_peashooterItem.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush Dea_WallnutItemBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "dea_wallnutItem.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush Dea_CherryBombItemBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "dea_cherrybombItem.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush Dea_SnowPeaItemBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "dea_snowpeashooterItem.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush Dea_PotatoMineItemBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "dea_potatomineItem.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush ShovelBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "shovel.png"), UriKind.RelativeOrAbsolute)));

        public static readonly Brush DiedBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "gameover.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush WaveBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "hugewave.png"), UriKind.RelativeOrAbsolute)));
    }
}
