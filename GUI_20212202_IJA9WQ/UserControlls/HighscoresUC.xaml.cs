using GUI_20212202_IJA9WQ.Logic;
using GUI_20212202_IJA9WQ.ViewModels;
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
    /// Interaction logic for HighscoresUC.xaml
    /// </summary>
    /// 
    public partial class HighscoresUC : UserControl
    {
        IViewLogic viewLogic;

        public List<string> Highscores { get; set; }
        public HighscoresUC()
        {
            InitializeComponent();
            Highscores = new List<string>();
            this.DataContext = new HighscoresViewModel();
            viewLogic = (this.DataContext as HighscoresViewModel).viewLogic;
            lb.DataContext = Highscores;
        }
    }
}
