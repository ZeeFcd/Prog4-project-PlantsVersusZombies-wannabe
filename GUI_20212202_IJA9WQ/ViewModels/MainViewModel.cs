using GUI_20212202_IJA9WQ.Logic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System.ComponentModel;
using System.Windows;

namespace GUI_20212202_IJA9WQ.ViewModels
{
    public class MainViewModel : ObservableRecipient
    {
        public IViewLogic viewLogic { get; set; }
        public object View
        {
            get { return viewLogic.View; }
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
        public MainViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<IViewLogic>()) { }
        public MainViewModel(IViewLogic viewLogic)
        {
            this.viewLogic = viewLogic;

            viewLogic.ChangeView("menu");

            Messenger.Register<MainViewModel, string, string>(this, "Base", (recipient, msg) =>
            {
                OnPropertyChanged("View");
            });
        }

    }
}
