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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
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

        private void PlantSelectedSound()
        {   
            SoundPlayer soundP = new SoundPlayer(Sounds.seedlift);
            soundP.Play();
        }
        private void PlantPlacedSound()
        {
            SoundPlayer soundP = new SoundPlayer(Sounds.plant);
            soundP.Play();
        }
        private void ZombieBiteSound()
        {
            SoundPlayer soundP = new SoundPlayer(Sounds.plant);
            soundP.Play();
        }
        private void ShootSound()
        {
            SoundPlayer soundP = new SoundPlayer(Sounds.plant);
            soundP.Play();
        }
        private void SnowShootSound()
        {
            SoundPlayer soundP = new SoundPlayer(Sounds.plant);
            soundP.Play();
        }
        private void ZombiesStartedSound()
        {
            SoundPlayer soundP = new SoundPlayer(Sounds.plant);
            soundP.Play();
        }
        private void WaveSound()
        {
            SoundPlayer soundP = new SoundPlayer(Sounds.plant);
            soundP.Play();
        }
        private void SunCollectedSound()
        {
            SoundPlayer soundP = new SoundPlayer(Sounds.plant);
            soundP.Play();
        }
        private void ZombieGroanSound()
        {
            SoundPlayer soundP = new SoundPlayer(Sounds.plant);
            soundP.Play();
        }
        private void BulletHitSound()
        {
            SoundPlayer soundP = new SoundPlayer(Sounds.plant);
            soundP.Play();

        }
        private void PotatoMineExploisonSound()
        {
            SoundPlayer soundP = new SoundPlayer(Sounds.plant);
            soundP.Play();
        }
        private void LawMoverSound()
        {
            SoundPlayer soundP = new SoundPlayer(Sounds.plant);
            soundP.Play();
        }
        private void HugeWaveSound()
        {
            SoundPlayer soundP = new SoundPlayer(Sounds.plant);
            soundP.Play();
        }
        private void ZombieGulpSound()
        {
            SoundPlayer soundP = new SoundPlayer(Sounds.plant);
            soundP.Play();
        }
        private void CherrybombSound()
        {
            SoundPlayer soundP = new SoundPlayer(Sounds.plant);
            soundP.Play();

        }
        //private void Sound()
        //{

        //}
        //private void Sound()
        //{

        //}
        //private void Sound()
        //{

        //}

    }
}
