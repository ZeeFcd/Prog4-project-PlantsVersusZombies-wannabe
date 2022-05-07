using GUI_20212202_IJA9WQ.UserControlls;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace GUI_20212202_IJA9WQ.Logic
{
    public class ViewLogic : IViewLogic
    {
        public object View { get; set; }
        IMessenger messenger;
        public ViewLogic(IMessenger messenger)
        {
            
            this.messenger = messenger;
        }
        public void ChangeView(string view)
        {
            switch (view)
            {
                case "game":
                    ;
                    View = new GameUC();
                    break;
                case "menu":
                    View = new MenuUC();
                    break;
                default:
                    break;
            }
            messenger.Send("viewChanged", "Base");
        }
    }
}
