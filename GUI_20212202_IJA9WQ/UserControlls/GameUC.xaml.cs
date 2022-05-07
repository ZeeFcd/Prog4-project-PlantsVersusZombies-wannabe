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

        DispatcherTimer gamestepDT;
        DispatcherTimer displayDT;
        GameLogic logic;
        ViewLogic viewLogic;
        CoordinateCalculator coordinateCalculator;
        GameAnimationBrushes brushes;
        double mouseX;
        double mouseY;

        public GameUC()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            coordinateCalculator = new CoordinateCalculator(grid.ActualWidth, grid.ActualHeight);
            logic = new GameLogic(coordinateCalculator);
            brushes = new GameAnimationBrushes();
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
            displayDT.Interval = TimeSpan.FromMilliseconds(10);
            displayDT.Tick += (sender, eventargs) =>
            {
                display.InvalidateVisual();
            };



            gamestepDT.Start();
            displayDT.Start();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            double x = e.GetPosition(grid).X;
            double y = e.GetPosition(grid).Y;
            bool isingamemap = coordinateCalculator.IsInGameMap(x, y);

            if (coordinateCalculator.IsInShop(x, y))
            {
                logic.PlantSelect(coordinateCalculator.WhichCellInShop(y));
                display.SetMouse(mouseX, mouseY);
                display.InvalidateVisual();
            }
            else if (logic.CurrentlySelectedIndex != -1 && isingamemap)
            {
                (int, int) gameCellindexes = coordinateCalculator.WhichCellInGameMap(x, y);
                logic.PlantToPlant(gameCellindexes.Item1, gameCellindexes.Item2);
                display.InvalidateVisual();
            }
            else if (!logic.ShovelSelected && coordinateCalculator.IsShovel(x, y))
            {
                logic.ShovelSelect();
                display.InvalidateVisual();
            }
            else if (logic.ShovelSelected && isingamemap)
            {
                (int, int) gameCellindexes = coordinateCalculator.WhichCellInGameMap(x, y);
                logic.PlantDelete(gameCellindexes.Item1, gameCellindexes.Item2);
                display.InvalidateVisual();
            }
            else if (isingamemap)
            {
                logic.IsSunSelected(x, y);
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
        private void Pause()
        {

        }
        private void BackToMenu()
        {
            
        }
    }
}
