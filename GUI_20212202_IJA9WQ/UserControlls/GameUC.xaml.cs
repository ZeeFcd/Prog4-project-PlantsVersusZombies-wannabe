using GUI_20212202_IJA9WQ.Logic;
using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace GUI_20212202_IJA9WQ.UserControlls
{
    /// <summary>
    /// Interaction logic for GameUC.xaml
    /// </summary>
    public partial class GameUC : UserControl
    {

        GameLogic logic;
        DispatcherTimer dt = new DispatcherTimer();

        public GameUC()
        {
            logic = new GameLogic((int)grid.ActualWidth, (int)grid.ActualHeight);
            InitializeComponent();
            display.SetupLogic(logic);
            display.InvalidateVisual();
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(17);
            dt.Tick += (sender, eventargs) =>
            {
                logic.TimeStep();
                display.InvalidateVisual();
            };
            dt.Start();
        }
    }
}
