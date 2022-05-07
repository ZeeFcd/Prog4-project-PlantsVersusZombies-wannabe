using GUI_20212202_IJA9WQ.Assets;
using GUI_20212202_IJA9WQ.Helpers;
using GUI_20212202_IJA9WQ.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
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
        DispatcherTimer dt;
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
            coordinateCalculator.SetUpLogic(logic);

            display.SetupLogic(logic);
            display.SetupCoordinateCalculator(coordinateCalculator);
            display.SetupBrushes(brushes);
            display.InvalidateVisual();

            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(17);
            dt.Tick += (sender, eventargs) =>
            {
                logic.TimeStep();
                display.InvalidateVisual();
            };
            dt.Start();
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
            else if (!logic.ShovelSelected&&coordinateCalculator.IsShovel(x,y))
            {
                logic.ShovelSelect();
                display.SetMouse(mouseX, mouseY);
                display.InvalidateVisual();
            }
            else if (logic.ShovelSelected&& isingamemap)
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
                display.InvalidateVisual();
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.GetPosition(grid).X;
            mouseY = e.GetPosition(grid).Y;
            display.SetMouse(mouseX, mouseY);
            display.InvalidateVisual();
        }
    }
}
