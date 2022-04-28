using GUI_20212202_IJA9WQ.Logic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_IJA9WQ.ViewModels
{
    public  class MainWindowViewModel:ObservableObject
    {
        IGameLogic gameLogic;
        public object View { get; set; }
        public MainWindowViewModel()
        {

        }
        public MainWindowViewModel(IGameLogic gameLogic)
        {
            gameLogic.ChangeView("menu");
        }
    }
}
