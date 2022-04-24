using GUI_20212202_IJA9WQ.Logic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_20212202_IJA9WQ.ViewModels
{
    public class MainViewModel : ObservableRecipient
    {
        public IGameLogic gameLogic { get; set; }
        public object View
        {
            get { return gameLogic.View; }
        }
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
        public MainViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<IGameLogic>()) { }
        public MainViewModel(IGameLogic gameLogic)
        {
            this.gameLogic = gameLogic;
            gameLogic.ChangeView("menu");

        }
    }
}
