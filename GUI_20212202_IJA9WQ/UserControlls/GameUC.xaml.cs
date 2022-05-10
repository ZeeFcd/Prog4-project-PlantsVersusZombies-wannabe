using GUI_20212202_IJA9WQ.Assets;
using GUI_20212202_IJA9WQ.Helpers;
using GUI_20212202_IJA9WQ.Logic;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace GUI_20212202_IJA9WQ.UserControlls
{
    /// <summary>
    /// Interaction logic for GameUC.xaml
    /// </summary>
    public partial class GameUC : UserControl
    {

      
        IViewLogic viewLogic;
        DispatcherTimer gamestepDT;
        DispatcherTimer displayDT;
        DispatcherTimer timer;
        DispatcherTimer DeathTimer;
        GameLogic logic;
        CoordinateCalculator coordinateCalculator;
        GameAnimationBrushes brushes;
        int deathtime;
        DateTime score;
        ISoundGame sounds;
        double mouseX;
        double mouseY;
        bool gameended;
        bool ispaused;

        public GameUC(IViewLogic viewLogic)
        {
            InitializeComponent();
            this.viewLogic = viewLogic;
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            coordinateCalculator = new CoordinateCalculator(grid.ActualWidth, grid.ActualHeight);
            logic = new GameLogic(coordinateCalculator);
            brushes = new GameAnimationBrushes();
            gameended = false;
            sounds = new Sounds();
            sounds.LoadGamesSFX();

            logic.ZombieBiteSound += sounds.ZombieBiteSound;
            logic.ShootSound += sounds.ShootSound;
            logic.SnowShootSound += sounds.SnowShootSound;
            logic.ZombiesStartedSound += sounds.ZombiesStartedSound;
            logic.WaveSound += sounds.WaveSound;
            logic.SunCollectedSound += sounds.SunCollectedSound;
            logic.ZombieGroanSound += sounds.ZombieGroanSound;
            logic.BulletHitSound += sounds.BulletHitSound;
            logic.ShovelSound += sounds.ShovelSound;
            logic.PlantSelectedSound += sounds.PlantSelectedSound;
            logic.PotatoMineExploisonSound += sounds.PotatoMineExploisonSound;
            logic.PlantPlacedSound += sounds.PlantPlacedSound;
            logic.LawMoverSound += sounds.LawMoverSound;
            logic.ZombieBiteSound += sounds.ZombieBiteSound;
            logic.ZombieGulpSound += sounds.ZombieGulpSound;
            logic.CherrybombSound += sounds.CherrybombSound;
            logic.ScreamSound += sounds.ScreamSound;
            logic.HugeWaveSound += sounds.HugeWaveSound;
            logic.GameOver += Gameover;

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

            score = new DateTime();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (sender, eventargs) =>
            {
                score=score.AddSeconds(1);
            };

            deathtime = 0;
            DeathTimer = new DispatcherTimer();
            DeathTimer.Interval = TimeSpan.FromSeconds(1);
            DeathTimer.Tick += (sender, eventargs) =>
            {
                Deathtimer();
                deathtime++;
            };


            gamestepDT.Start();
            displayDT.Start();
            timer.Start();
            sounds.Daymusic();
        }

        private void Gameover()
        {
            gamestepDT.Stop();
            displayDT.Stop();
            sounds.DaymusicStop();
            timer.Stop();
            gameended = true;
            DeathTimer.Start();
        }
        private void Deathtimer()
        {
            if (deathtime==4)
            {
                DeathTimer.Stop();
                HighscoreManager manager = new HighscoreManager();
                NameInput nameinput = new NameInput(score.ToString("mm:ss"));
                nameinput.ShowDialog();
                manager.Add((nameinput.YourName, score.ToString("mm:ss")));
                BackToMenu();
            }
        }

        private void Pause()
        {
            gamestepDT.Stop();
            displayDT.Stop();
            timer.Stop();
            ispaused = true;
            PauseMenu pause = new PauseMenu();

            if ((bool)pause.ShowDialog())
            {
                gameended = true;
                sounds.DaymusicStop();
                BackToMenu();
            }
            else
            {
                gamestepDT.Start();
                displayDT.Start();
                timer.Start();
                ispaused = false;
            }

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!gameended&&!ispaused)
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
                else if (!logic.ShovelSelected && coordinateCalculator.IsShovel(mouseX, mouseY))
                {
                    logic.ShovelSelect();
                    display.InvalidateVisual();
                }
                else if (logic.ShovelSelected && isingamemap)
                {
                    (int, int) gameCellindexes = coordinateCalculator.WhichCellInGameMap(mouseX, mouseY);
                    logic.PlantDelete(gameCellindexes.Item1, gameCellindexes.Item2);
                    sounds.ShovelSound();
                    display.InvalidateVisual();
                }
                else if (isingamemap)
                {
                    logic.IsSunSelected(mouseX, mouseY);
                    display.InvalidateVisual();
                }
                else if (coordinateCalculator.IsGamePause(mouseX,mouseY))
                {
                    Pause();
                }
                display.InvalidateVisual();
            }
           
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

        private void BackToMenu()
        {
            viewLogic.ChangeView("menu");
        }
    }
}
