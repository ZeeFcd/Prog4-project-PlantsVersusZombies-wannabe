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
    public static class GameAnimationBrushes
    {
        public static readonly Brush SunflowerNormal1 = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images","Animations" ,"background_day.png"), UriKind.RelativeOrAbsolute)));

    }
}
