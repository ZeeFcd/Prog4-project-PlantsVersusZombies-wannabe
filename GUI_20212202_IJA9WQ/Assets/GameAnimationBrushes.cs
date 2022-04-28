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
    public class GameAnimationBrushes
    {
        public List<Brush> PeashooterGIFS;
        public List<Brush> SunfloowerGIFS;
        public List<Brush> SnowpeashooterGIFS;
        public List<Brush> PotatomineGIFS;
        public List<Brush> WallnutGIFS;

        public GameAnimationBrushes()
        {
            PeashooterGIFS = BrushesReader("peashooterAnimation");
            SunfloowerGIFS = BrushesReader("sunflowerAnimation");
            SnowpeashooterGIFS = BrushesReader("snowpeashooterAnimation");
            PotatomineGIFS = BrushesReader("potatomineAnimation");
            WallnutGIFS = BrushesReader("wallnutAnimation");
        }
        public List<Brush> BrushesReader(string path)
        {
            List<Brush> brushes = new List<Brush>();
            string[] files = Directory.GetFiles(Path.Combine("Images", path));
            string filename = Path.GetFileName(files[0]).Substring(0, 11);
            string format = Path.GetFileName(files[0]).Substring(14);
            for (int i = 1; i < files.Length + 1; i++)
            {
                brushes.Add(new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", filename + "(" + i + ")" + format), UriKind.RelativeOrAbsolute))));
            }
            return brushes;
        }
    }
}
