using GUI_20212202_IJA9WQ.Logic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI_20212202_IJA9WQ.ViewModels
{
    public class MenuViewModel : ObservableRecipient
    {
        public ICommand StartCommand { get; set; }
        public ICommand MuteCommand { get; set; }
        


    }
}
