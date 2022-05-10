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
    /// Interaction logic for NameInput.xaml
    /// </summary>
    public partial class NameInput : Window
    {
        string YourTime;
        public string YourName { get => name.Text; }
        public NameInput(string time)
        {
            InitializeComponent();
            this.YourTime = time;
            yourtime.Content = YourTime;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                DialogResult = true;
            }
        }
    }
}
