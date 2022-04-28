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
        IViewLogic viewLogic;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            viewLogic = new ViewLogic();
            viewLogic.ChangeView("menu");

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int x = (int)e.GetPosition(grid).X;
            int y = (int)e.GetPosition(grid).Y;

            if (10 < x && x < 114 && 10 < y && y < 415)
            {
                int z = y-10;
                int cellnumber = z / (int)(410 / 6);
                logic.PlantSelect(cellnumber);
            }
            else if (logic.CurrentlySelected != null && 260 < x && x < 970 && 75 < y && y < 565)
            {
                int temp = (int)(715 / 9);
                int i = (x-260) / temp;
                
                int temp2 = (int)(490 / 5);
                int j = (y-75) / temp2;
                ;
                logic.PlantToPlant(i,j,temp * i +260, temp2 * j+99);
            }

            display.InvalidateVisual();
        }
    }
}
