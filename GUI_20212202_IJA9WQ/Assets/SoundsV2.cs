using System;
using WMPLib;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media;
using GUI_20212202_IJA9WQ.Helpers;

namespace GUI_20212202_IJA9WQ.Assets
{
    class SoundsV2
    {
        bool menumuted;
       
        WindowsMediaPlayer seedlift;
        WindowsMediaPlayer plant;
        WindowsMediaPlayer zombiebite;
        WindowsMediaPlayer throw1;
        WindowsMediaPlayer snowpeasparkles;
        WindowsMediaPlayer startwave;
        WindowsMediaPlayer siren;
        WindowsMediaPlayer sun;
        WindowsMediaPlayer groan1;
        WindowsMediaPlayer splat1;
        WindowsMediaPlayer potatomine;
        WindowsMediaPlayer lawnmover;
        WindowsMediaPlayer hugewave;
        WindowsMediaPlayer gulp;
        WindowsMediaPlayer cherrybomb;
        MediaPlayer daymusic;
        WindowsMediaPlayer shovel;
        WindowsMediaPlayer losemusic;
        MediaPlayer mainmenu;

        public List<String> Groan;
        public List<String> Throw;
        public List<String> Splat;
        WindowsMediaPlayer groan;
        WindowsMediaPlayer throwt;
        WindowsMediaPlayer splat;

        public SoundsV2()
        {
            menumuted = false;

            seedlift = new WindowsMediaPlayer();
            plant = new WindowsMediaPlayer();
            zombiebite = new WindowsMediaPlayer();
            snowpeasparkles = new WindowsMediaPlayer();
            startwave = new WindowsMediaPlayer();
            siren = new WindowsMediaPlayer();
            sun = new WindowsMediaPlayer();
            potatomine = new WindowsMediaPlayer();
            lawnmover = new WindowsMediaPlayer();
            hugewave = new WindowsMediaPlayer();
            gulp = new WindowsMediaPlayer();
            cherrybomb = new WindowsMediaPlayer();
            daymusic = new MediaPlayer();
            shovel = new WindowsMediaPlayer();
            losemusic = new WindowsMediaPlayer();

            groan = new WindowsMediaPlayer();
            throwt = new WindowsMediaPlayer();
            splat = new WindowsMediaPlayer();

            daymusic = new MediaPlayer();
            daymusic.Open(new Uri(Path.Combine("Sound", "daymusic.wav"), UriKind.RelativeOrAbsolute));
            daymusic.MediaEnded += Media_Endedmusic;
            daymusic.Volume = 0.2;

            Groan = SoundReader("Groan");
            Throw = SoundReader("Throw");
            Splat = SoundReader("Splat");

            mainmenu = new MediaPlayer();
            mainmenu.Open(new Uri(Path.Combine("Sound", "MainMenuPvZ1.wav"), UriKind.RelativeOrAbsolute));
            mainmenu.MediaEnded += Media_Endedmusic;
            mainmenu.Volume = 0.2;

            mainmenu = new MediaPlayer();
        }

        public List<String> SoundReader(string path)
        {
           
            string[] files = Directory.GetFiles(Path.Combine("Sound", path));
           
            return files.ToList();
        }

        public void MainMenuMute()
        {
            if (menumuted)
            {
                mainmenu.Play();
            }
            else
            {
                mainmenu.Pause();
            }
        }

        public void Daymusic()
        {
            daymusic.Play();
        }

        public void ShovelSound()
        {
            shovel.URL = Path.Combine("Sound", "Shovel.wav");


        }
        public void PlantSelectedSound()
        {
            seedlift.URL = Path.Combine("Sound", "seedlift.wav");

        }
        public void PlantPlacedSound()
        {
         
            plant.URL= Path.Combine("Sound", "Plant.wav");
        }
        public void ZombieBiteSound()
        {
            zombiebite.URL = Path.Combine("Sound", "zombiebite.wav");
        }
        public void ShootSound()
        {

            int random = RandomGenerator.Rand.Next(0, Throw.Count);
            throwt.URL = Throw[random];
        }
        public void SnowShootSound()
        {
           snowpeasparkles.URL= Path.Combine("Sound", "Snow_pea_sparkles.wav");
        }
        public void ZombiesStartedSound()
        {
            startwave.URL = Path.Combine("Sound", "startwave.wav");
        }
        public void WaveSound()
        {
            siren.URL = Path.Combine("Sound", "siren.wav");

        }
        public void SunCollectedSound()
        {
            siren.URL = Path.Combine("Sound", "sun.wav");
        }
        public void ZombieGroanSound()
        {
            int random = RandomGenerator.Rand.Next(0, Groan.Count);
            siren.URL = Groan[random];

        }
        public void BulletHitSound()
        {
            int random = RandomGenerator.Rand.Next(0, Splat.Count);
            siren.URL = Splat[random];

        }
        public void PotatoMineExploisonSound()
        {
            potatomine.URL = Path.Combine("Sound", "Potato_mine.wav");
        }
        public void LawMoverSound()
        {
            potatomine.URL = Path.Combine("Sound", "Lawnmower.wav");
        }
        public void HugeWaveSound()
        {
            hugewave.URL = Path.Combine("Sound", "hugewave.wav");
        }
        public void ZombieGulpSound()
        {
            gulp.URL = Path.Combine("Sound", "Gulp.wav");
        }
        public void CherrybombSound()
        {
            cherrybomb.URL = Path.Combine("Sound", "Cherrybomb.wav");
        }

        public void Media_Endedmusic(object sender, EventArgs e)
        {
            (sender as MediaPlayer).Position = TimeSpan.Zero;

        }



    }
}
