using GUI_20212202_IJA9WQ.Logic;
using GUI_20212202_IJA9WQ.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            this.DataContext = new MenuViewModel();
            viewLogic = (this.DataContext as MenuViewModel).viewLogic;
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.Sleep(300);
            System.Windows.Application.Current.Shutdown();
        }
    }
}
