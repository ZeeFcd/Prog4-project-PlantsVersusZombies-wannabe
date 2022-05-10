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
using System.Windows.Shapes;

namespace GUI_20212202_IJA9WQ
{
    /// <summary>
    /// Interaction logic for PauseMenu.xaml
    /// </summary>
    public partial class PauseMenu : Window
    {
        public PauseMenu()
        {
            InitializeComponent();
        }

        private void yes_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void no_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
