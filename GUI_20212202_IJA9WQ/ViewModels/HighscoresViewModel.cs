using GUI_20212202_IJA9WQ.Logic;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUI_20212202_IJA9WQ.ViewModels
{
    public class HighscoresViewModel
    {
        public IViewLogic viewLogic { get; set; }
        public ICommand BackToMenuCommand { get; set; }
        public List<string> Highscores { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                return
                    (bool)DependencyPropertyDescriptor
                    .FromProperty(DesignerProperties.
                    IsInDesignModeProperty,
                    typeof(FrameworkElement))
                    .Metadata.DefaultValue;
            }
        }
        public HighscoresViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<IViewLogic>()) { }
        public HighscoresViewModel(IViewLogic viewLogic)
        {
            Highscores = new List<string>() { "11:20", "11dsadads01", "11:00" };
            this.viewLogic = viewLogic;
            BackToMenuCommand = new RelayCommand(()=> viewLogic.ChangeView("menu"));
        }
    }
}
