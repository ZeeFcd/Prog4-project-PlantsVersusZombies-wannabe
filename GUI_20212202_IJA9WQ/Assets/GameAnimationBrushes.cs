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
        public List<Brush> PeashooterGIF;
        public List<Brush> SunfloowerGIF;
        public List<Brush> SnowpeashooterGIF;
        public List<Brush> PotatomineGIF;
        public List<Brush> WallnutGIF;
        public List<Brush> ZombieWalkGIF;
        public List<Brush> ZombieEatGIF;
        public List<Brush> ZombieDeathGIF;
        public List<Brush> ZombieAshGIF;
        public List<Brush> CherryGIF;
        public List<Brush> PowieGIF;

        public GameAnimationBrushes()
        {
            PeashooterGIF = BrushesReader("peashooterAnimation");
            SunfloowerGIF = BrushesReader("sunflowerAnimation");
            SnowpeashooterGIF = BrushesReader("snowpeashooterAnimation");
            PotatomineGIF = BrushesReader("potatomineAnimation");
            WallnutGIF = BrushesReader("wallnutAnimation");
            ZombieWalkGIF = BrushesReader("zombiewalkAnimation");
            ZombieEatGIF = BrushesReader("zombieeatAnimation");
            ZombieDeathGIF = BrushesReader("zombiedeathAnimation");
            ZombieAshGIF = BrushesReader("zombieashAnimation");
            CherryGIF = BrushesReader("cherryAnimation");
            PowieGIF = BrushesReader("powieAnimation");
        }
        private List<Brush> BrushesReader(string path)
        {
            List<Brush> brushes = new List<Brush>();
            string[] files = Directory.GetFiles(Path.Combine("Images", path));
            string[] filenameandtype = new string[files.Length];
            for (int i = 1; i < files.Length + 1; i++)
            {
                filenameandtype = Path.GetFileName(files[0]).Split(" ");
                brushes.Add(new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", path, filenameandtype[0] + " (" + i + ")" + filenameandtype[1].Substring(3)), UriKind.RelativeOrAbsolute))));
            }
            return brushes;
        }
    }
}
