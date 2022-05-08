using GUI_20212202_IJA9WQ.Assets;
using GUI_20212202_IJA9WQ.Helpers;
using GUI_20212202_IJA9WQ.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GUI_20212202_IJA9WQ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer gamestepDT;
        DispatcherTimer displayDT;
        GameLogic logic;
        CoordinateCalculator coordinateCalculator;
        GameAnimationBrushes brushes;
        double mouseX;
        double mouseY;
        MediaPlayer seedlift;
        MediaPlayer plant;
        MediaPlayer zombiebite;
        MediaPlayer throw1;
        MediaPlayer snowpeasparkles;
        MediaPlayer startwave;
        MediaPlayer siren;
        MediaPlayer sun;
        MediaPlayer groan1;
        MediaPlayer splat1;
        MediaPlayer potatomine;
        MediaPlayer lawnmover;
        MediaPlayer hugewave;
        MediaPlayer gulp;
        MediaPlayer cherrybomb;
        MediaPlayer daymusic;




        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MediaplayerInitialize();
            coordinateCalculator = new CoordinateCalculator(grid.ActualWidth, grid.ActualHeight);
            logic = new GameLogic(coordinateCalculator);
            brushes = new GameAnimationBrushes();

            logic.ZombieBiteSound+= ZombieBiteSound;
            logic.ShootSound += ShootSound;
            logic.SnowShootSound += SnowShootSound;
            logic.ZombiesStartedSound += ZombiesStartedSound;
            logic.WaveSound += WaveSound;
            logic.SunCollectedSound += SunCollectedSound;
            logic.ZombieGroanSound += ZombieGroanSound;
            logic.BulletHitSound += BulletHitSound;
            //logic.ShovelSound += ShovelSound;
            logic.PlantSelectedSound += PlantSelectedSound;
            logic.PotatoMineExploisonSound += PotatoMineExploisonSound;
            logic.PlantPlacedSound += PlantPlacedSound;
            logic.LawMoverSound += LawMoverSound;
            logic.ZombieBiteSound += ZombieBiteSound;
            logic.ZombieGulpSound += ZombieGulpSound;
            logic.CherrybombSound += CherrybombSound;

            coordinateCalculator.SetUpLogic(logic);
            display.SetupLogic(logic);
            display.SetupCoordinateCalculator(coordinateCalculator);
            display.SetupBrushes(brushes);
            display.InvalidateVisual();

            gamestepDT = new DispatcherTimer();
            gamestepDT.Interval = TimeSpan.FromMilliseconds(17);
            gamestepDT.Tick += (sender, eventargs) =>
            {
                logic.TimeStep();
                display.InvalidateVisual();
            };

            displayDT = new DispatcherTimer();
            displayDT.Interval = TimeSpan.FromMilliseconds(5);
            displayDT.Tick += (sender, eventargs) =>
            {
                display.InvalidateVisual();
            };


            gamestepDT.Start();
            displayDT.Start();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            bool isingamemap = coordinateCalculator.IsInGameMap(mouseX, mouseY);

            if (coordinateCalculator.IsInShop(mouseX, mouseY))
            {
                logic.PlantSelect(coordinateCalculator.WhichCellInShop(mouseY));

                display.InvalidateVisual();
            }
            else if (logic.CurrentlySelectedIndex != -1 && isingamemap)
            {
                (int, int) gameCellindexes = coordinateCalculator.WhichCellInGameMap(mouseX, mouseY);
                logic.PlantToPlant(gameCellindexes.Item1, gameCellindexes.Item2);
                display.InvalidateVisual();
            }         
            else if (!logic.ShovelSelected&&coordinateCalculator.IsShovel(mouseX, mouseY))
            {
                logic.ShovelSelect();
                display.InvalidateVisual();
            }
            else if (logic.ShovelSelected&& isingamemap)
            {
                (int, int) gameCellindexes = coordinateCalculator.WhichCellInGameMap(mouseX, mouseY);
                logic.PlantDelete(gameCellindexes.Item1, gameCellindexes.Item2);
                display.InvalidateVisual();
            }
            else if (isingamemap)
            {
                logic.IsSunSelected(mouseX, mouseY);
                display.InvalidateVisual();
            }
            display.InvalidateVisual();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (coordinateCalculator != null)
            {
                coordinateCalculator.Resize(grid.ActualWidth, grid.ActualHeight);
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.GetPosition(grid).X;
            mouseY = e.GetPosition(grid).Y;
            display.SetMouse(mouseX, mouseY);
            display.InvalidateVisual();   
        }

        private void MediaplayerInitialize() 
        {
            seedlift = new MediaPlayer();
            seedlift.Open(new Uri(Sounds.seedlift, UriKind.RelativeOrAbsolute));
            seedlift.MediaEnded+= Media_Ended;
            plant = new MediaPlayer();
            plant.Open(new Uri(Sounds.plant, UriKind.RelativeOrAbsolute));
            plant.MediaEnded += Media_Ended;
            zombiebite = new MediaPlayer();
            zombiebite.Open(new Uri(Sounds.zombiebite, UriKind.RelativeOrAbsolute));
            zombiebite.MediaEnded += Media_Ended;
            throw1 = new MediaPlayer();
            throw1.Open(new Uri(Sounds.throw1, UriKind.RelativeOrAbsolute));
            throw1.MediaEnded += Media_Ended;
            snowpeasparkles = new MediaPlayer();
            snowpeasparkles.Open(new Uri(Sounds.snowpeasparkles, UriKind.RelativeOrAbsolute));
            snowpeasparkles.MediaEnded += Media_Ended;
            startwave = new MediaPlayer();
            startwave.Open(new Uri(Sounds.startwave, UriKind.RelativeOrAbsolute));
            startwave.MediaEnded += Media_Ended;
            siren = new MediaPlayer();
            siren.Open(new Uri(Sounds.siren, UriKind.RelativeOrAbsolute));
            siren.MediaEnded += Media_Ended;
            sun = new MediaPlayer();
            sun.Open(new Uri(Sounds.sun, UriKind.RelativeOrAbsolute));
            sun.MediaEnded += Media_Ended;
            groan1 = new MediaPlayer();
            groan1.Open(new Uri(Sounds.groan1, UriKind.RelativeOrAbsolute));
            groan1.MediaEnded += Media_Ended;
            splat1 = new MediaPlayer();
            splat1.Open(new Uri(Sounds.splat1, UriKind.RelativeOrAbsolute));
            splat1.MediaEnded += Media_Ended;
            potatomine = new MediaPlayer();
            potatomine.Open(new Uri(Sounds.potatomine, UriKind.RelativeOrAbsolute));
            potatomine.MediaEnded += Media_Ended;
            lawnmover = new MediaPlayer();
            lawnmover.Open(new Uri(Sounds.lawnmover, UriKind.RelativeOrAbsolute));
            lawnmover.MediaEnded += Media_Ended;
            hugewave = new MediaPlayer();
            hugewave.Open(new Uri(Sounds.hugewave, UriKind.RelativeOrAbsolute));
            hugewave.MediaEnded += Media_Ended;
            gulp = new MediaPlayer();
            gulp.Open(new Uri(Sounds.gulp, UriKind.RelativeOrAbsolute));
            gulp.MediaEnded += Media_Ended;
            cherrybomb = new MediaPlayer();
            cherrybomb.Open(new Uri(Sounds.cherrybomb, UriKind.RelativeOrAbsolute));
            cherrybomb.MediaEnded += Media_Ended;
            daymusic = new MediaPlayer();
            daymusic.Open(new Uri(Sounds.daymusic, UriKind.RelativeOrAbsolute));
            daymusic.MediaEnded += Media_Endedmusic;

            daymusic.Play();
        }
        private void PlantSelectedSound()
        {
            seedlift.Play();

        }
        private void PlantPlacedSound()
        {
            plant.Play();

        }
        private void ZombieBiteSound()
        {
            zombiebite.Play();
        }
        private void ShootSound()
        {
            throw1.Play();
        }
        private void SnowShootSound()
        {

            snowpeasparkles.Play();
        }
        private void ZombiesStartedSound()
        {
            startwave.Play();
        }
        private void WaveSound()
        {
            siren.Play();

        }
        private void SunCollectedSound()
        {
            sun.Play();
        }
        private void ZombieGroanSound()
        {
            groan1.Play();

        }
        private void BulletHitSound()
        {
            splat1.Play();

        }
        private void PotatoMineExploisonSound()
        {
            potatomine.Play();
        }
        private void LawMoverSound()
        {
            lawnmover.Play();
        }
        private void HugeWaveSound()
        {
            hugewave.Play();
        }
        private void ZombieGulpSound()
        {
            gulp.Play();
        }
        private void CherrybombSound()
        {
            cherrybomb.Play();

        }


        private void Media_Ended(object sender, EventArgs e)
        {
            (sender as MediaPlayer).Position = TimeSpan.Zero;
            (sender as MediaPlayer).Stop();
        }
        private void Media_Endedmusic(object sender, EventArgs e)
        {
            (sender as MediaPlayer).Position = TimeSpan.Zero;
            
        }
    }
}
