using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace GUI_20212202_IJA9WQ.Assets
{
    static class AnimatedImages
    {
        public static readonly BitmapImage PeashooterImage = new BitmapImage(new Uri(Path.Combine("Images", "peashooter.png"), UriKind.RelativeOrAbsolute));
        public static readonly BitmapImage SunflowerImage = new BitmapImage(new Uri(Path.Combine("Images", "sunflowerAnim.gif"), UriKind.RelativeOrAbsolute));
    }
}
