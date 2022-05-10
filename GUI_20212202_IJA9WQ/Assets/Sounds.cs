using GUI_20212202_IJA9WQ.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GUI_20212202_IJA9WQ.Assets
{
    public class Sounds
    {
        bool menumuted;
        MediaPlayer seedlift;
        MediaPlayer plant;
        MediaPlayer zombiebite;
        MediaPlayer snowpeasparkles;
        MediaPlayer startwave;
        MediaPlayer siren;
        MediaPlayer sun;
        MediaPlayer potatomine;
        MediaPlayer lawnmover;
        MediaPlayer hugewave;
        MediaPlayer gulp;
        MediaPlayer cherrybomb;
        MediaPlayer daymusic;
        MediaPlayer shovel;
        MediaPlayer scream;
        MediaPlayer mainmenu;

        public List<MediaPlayer> Groan;
        public List<MediaPlayer> Throw;
        public List<MediaPlayer> Splat;
        public Sounds()
        {
            menumuted=false;
            mainmenu = new MediaPlayer();
            mainmenu.Open(new Uri(Path.Combine("Sound", "MainMenuPvZ1.wav"), UriKind.RelativeOrAbsolute));
            mainmenu.MediaEnded += Media_Endedmusic;
            mainmenu.Volume = 0.2;
        }

        public void LoadGamesSFX() 
        {
            seedlift = new MediaPlayer();

            seedlift.Open(new Uri(Path.Combine("Sound", "seedlift.wav"), UriKind.RelativeOrAbsolute));
            seedlift.MediaEnded += Media_Ended;

            plant = new MediaPlayer();
            plant.Open(new Uri(Path.Combine("Sound", "Plant.wav"), UriKind.RelativeOrAbsolute));
            plant.MediaEnded += Media_Ended;

            zombiebite = new MediaPlayer();
            zombiebite.Open(new Uri(Path.Combine("Sound", "ZombieBite.wav"), UriKind.RelativeOrAbsolute));
            zombiebite.MediaEnded += Media_Ended;

            snowpeasparkles = new MediaPlayer();
            snowpeasparkles.Open(new Uri(Path.Combine("Sound", "Snow_pea_sparkles.wav"), UriKind.RelativeOrAbsolute));
            snowpeasparkles.MediaEnded += Media_Ended;

            startwave = new MediaPlayer();
            startwave.Open(new Uri(Path.Combine("Sound", "startwave.wav"), UriKind.RelativeOrAbsolute));
            startwave.MediaEnded += Media_Ended;

            siren = new MediaPlayer();
            siren.Open(new Uri(Path.Combine("Sound", "siren.wav"), UriKind.RelativeOrAbsolute));
            siren.MediaEnded += Media_Ended;

            sun = new MediaPlayer();
            sun.Open(new Uri(Path.Combine("Sound", "Sun.wav"), UriKind.RelativeOrAbsolute));
            sun.MediaEnded += Media_Ended;

            potatomine = new MediaPlayer();
            potatomine.Open(new Uri(Path.Combine("Sound", "Potato_mine.wav"), UriKind.RelativeOrAbsolute));
            potatomine.MediaEnded += Media_Ended;

            lawnmover = new MediaPlayer();
            lawnmover.Open(new Uri(Path.Combine("Sound", "Lawnmower.wav"), UriKind.RelativeOrAbsolute));
            lawnmover.MediaEnded += Media_Ended;

            hugewave = new MediaPlayer();
            hugewave.Open(new Uri(Path.Combine("Sound", "hugewave.wav"), UriKind.RelativeOrAbsolute));
            hugewave.MediaEnded += Media_Ended;

            gulp = new MediaPlayer();
            gulp.Open(new Uri(Path.Combine("Sound", "Gulp.wav"), UriKind.RelativeOrAbsolute));
            gulp.MediaEnded += Media_Ended;

            cherrybomb = new MediaPlayer();
            cherrybomb.Open(new Uri(Path.Combine("Sound", "Cherrybomb.wav"), UriKind.RelativeOrAbsolute));
            cherrybomb.MediaEnded += Media_Ended;

            daymusic = new MediaPlayer();
            daymusic.Open(new Uri(Path.Combine("Sound", "daymusic.wav"), UriKind.RelativeOrAbsolute));
            daymusic.MediaEnded += Media_Endedmusic;
            daymusic.Volume = 0.2;

            shovel = new MediaPlayer();
            shovel.Open(new Uri(Path.Combine("Sound", "Shovel.wav"), UriKind.RelativeOrAbsolute));
            shovel.MediaEnded += Media_Ended;

            scream = new MediaPlayer();
            scream.Open(new Uri(Path.Combine("Sound", "scream.wav"), UriKind.RelativeOrAbsolute));
            scream.MediaEnded += Media_Ended;
            scream.Volume = 0.3;

            Groan = SoundReader("Groan");
            Throw = SoundReader("Throw");
            Splat = SoundReader("Splat");

        }
        public void LoadMenuSFX() 
        {

        }
        public List<MediaPlayer> SoundReader(string path)
        {
            List<MediaPlayer> sounds = new List<MediaPlayer>();
            string[] files = Directory.GetFiles(Path.Combine("Sound", path));
            for (int i = 0; i < files.Length ; i++)
            {
                MediaPlayer sound = new MediaPlayer();
                sound.Volume = 0;
                sound.Open(new Uri(files[i], UriKind.RelativeOrAbsolute));
                sound.MediaEnded += Media_Ended;
                sound.Volume = 1;
                sounds.Add(sound);
            }
            return sounds;
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
                menumuted = true;
            }
        }
        public void MainMenuStart()
        {   
             mainmenu.Play();   
        }
        public void MainMenuStop()
        {
            mainmenu.Stop();
        }

        public void Daymusic()
        {
           daymusic.Play();
        }
        public void DaymusicStop()
        {
            daymusic.Stop();
        }

        public void ShovelSound()
        {
            shovel.Position = TimeSpan.Zero;
            shovel.Play();
        }
        public void PlantSelectedSound()
        {
            seedlift.Position = TimeSpan.Zero;
            seedlift.Play();

        }
        public void PlantPlacedSound()
        {
            plant.Position = TimeSpan.Zero;
            plant.Play();

        }
        public void ZombieBiteSound()
        {
            zombiebite.Position = TimeSpan.Zero;
            zombiebite.Play();
        }
        public void ShootSound()
        {
            
            int random = RandomGenerator.Rand.Next(0, Throw.Count);
            Throw[random].Position = TimeSpan.Zero;
            Throw[random].Play();
        }
        public void SnowShootSound()
        {
            snowpeasparkles.Position = TimeSpan.Zero;
            snowpeasparkles.Play();
        }
        public void ZombiesStartedSound()
        {
            startwave.Position = TimeSpan.Zero;
            startwave.Play();
        }
        public void WaveSound()
        {
            siren.Position = TimeSpan.Zero;
            siren.Play();

        }
        public void SunCollectedSound()
        {
            sun.Position = TimeSpan.Zero;
            sun.Play();
        }
        public void ZombieGroanSound()
        {
            int random = RandomGenerator.Rand.Next(0, Groan.Count);
            Groan[random].Position = TimeSpan.Zero;
            Groan[random].Play();

        }
        public void BulletHitSound()
        {
            int random = RandomGenerator.Rand.Next(0, Splat.Count);
            Splat[random].Position = TimeSpan.Zero;
            Splat[random].Play();

        }
        public void PotatoMineExploisonSound()
        {
            potatomine.Position = TimeSpan.Zero;
            potatomine.Play();
        }
        public void LawMoverSound()
        {
            lawnmover.Position = TimeSpan.Zero;
            lawnmover.Play();
        }
        public void HugeWaveSound()
        {
            hugewave.Position = TimeSpan.Zero;
            hugewave.Play();
        }
        public void ZombieGulpSound()
        {
            gulp.Position = TimeSpan.Zero;
            gulp.Play();
        }
        public void CherrybombSound()
        {
            cherrybomb.Position = TimeSpan.Zero;
            cherrybomb.Play();
        }

        public void ScreamSound()
        {
            scream.Position = TimeSpan.Zero;
            scream.Play();
        }

        private void Media_Ended(object sender, EventArgs e)
        {
            (sender as MediaPlayer).Pause();
        }
        private void Media_Endedmusic(object sender, EventArgs e)
        {
            (sender as MediaPlayer).Position = TimeSpan.Zero;

        }

    }
}
