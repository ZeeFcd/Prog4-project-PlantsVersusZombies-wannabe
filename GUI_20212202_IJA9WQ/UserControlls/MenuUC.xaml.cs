using GUI_20212202_IJA9WQ.Logic;
using Microsoft.Toolkit.Mvvm.Input;
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

namespace GUI_20212202_IJA9WQ.UserControlls
{
    /// <summary>
    /// Interaction logic for MenuUC.xaml
    /// </summary>
    public partial class MenuUC : UserControl
    {
        IViewLogic viewLogic;
        public ICommand StartGameCommand { get; set; }

        public MenuUC()
        {
            InitializeComponent();
            //this.DataContext = new MenuUC();
            StartGameCommand = new RelayCommand(() => viewLogic.ChangeView("game"));
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.Sleep(300);
            System.Windows.Application.Current.Shutdown();
        }
    }
}
