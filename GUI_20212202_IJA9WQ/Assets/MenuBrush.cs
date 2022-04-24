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
    public static class MenuBrush
    {
        public static readonly Brush MuteButtonBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "mute.png"), UriKind.RelativeOrAbsolute)));
        public static readonly Brush MenuBackgroundBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "menuBackground.png"), UriKind.RelativeOrAbsolute)));

    }
}
