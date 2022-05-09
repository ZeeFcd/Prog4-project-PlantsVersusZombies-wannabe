using GUI_20212202_IJA9WQ.Logic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace GUI_20212202_IJA9WQ.ViewModels
{
    public class MenuViewModel : ObservableRecipient
    {
        public ICommand StartGameCommand { get; set; }
        public ICommand MuteCommand { get; set; }
        public IViewLogic viewLogic { get; set; }
        public ICommand HighscoreCommand { get; set; }
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
        public MenuViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<IViewLogic>()) { }
        public MenuViewModel(IViewLogic viewLogic)
        {
            this.viewLogic = viewLogic;
            StartGameCommand = new RelayCommand(() => viewLogic.ChangeView("game"));
            HighscoreCommand = new RelayCommand(()=> viewLogic.ChangeView("highscores"));
        }


    }
}
