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
        GeometryCalculator geometryCalculator;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            logic = new GameLogic((int)grid.ActualWidth, (int)grid.ActualHeight);
            coordinateCalculator = new CoordinateCalculator(grid.ActualWidth, grid.ActualHeight);
            geometryCalculator = new GeometryCalculator();

            display.SetupLogic(logic);
            display.SetupCoordinateCalculator(geometryCalculator);
            display.Resize(grid.ActualWidth, grid.ActualHeight);
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
            int x = (int)e.GetPosition(grid).X;
            int y = (int)e.GetPosition(grid).Y;

            int leftMapBorder = (int)Math.Round(0.25 * grid.ActualWidth);
            int rightMapBorder = (int)Math.Round(0.97 * grid.ActualWidth);
            int upperMapBorder = (int)Math.Round(0.15 * grid.ActualHeight);
            int lowerMapBorder = (int)Math.Round(0.95 * grid.ActualHeight);

            int leftShopBorder = (int)Math.Round(0.01 * grid.ActualWidth);
            int rightShopBorder = (int)Math.Round(0.11 * grid.ActualWidth);
            int upperShopBorder = (int)Math.Round(0.02 * grid.ActualHeight);
            int lowerShopBorder = (int)Math.Round(0.69 * grid.ActualHeight);

            ;
            if (leftShopBorder < x && x < rightShopBorder && upperShopBorder < y && y < lowerShopBorder)
            {
                int z = y- upperShopBorder;
                int cellnumber = z / (int)(lowerShopBorder / 6);
                logic.PlantSelect(cellnumber);
            }
            else if (logic.CurrentlySelected != null && leftMapBorder < x && x < rightMapBorder && upperMapBorder < y && y < lowerMapBorder)
            {
                int temp = (int)((rightMapBorder-leftMapBorder) / 9);
                int i = (x- leftMapBorder) / temp;
                
                int temp2 = (int)((lowerMapBorder- upperMapBorder) / 5);
                int j = (y- upperMapBorder) / temp2;
                

                logic.PlantToPlant(i,j,temp * i + leftMapBorder, temp2 * j+ upperMapBorder);
            }

            display.InvalidateVisual();
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (logic!=null)
            {
                logic.NewSize((int)grid.ActualWidth, (int)grid.ActualHeight);
                display.Resize(grid.ActualWidth, grid.ActualHeight);
                display.InvalidateVisual();
                
            }
           
        }
    }
}
