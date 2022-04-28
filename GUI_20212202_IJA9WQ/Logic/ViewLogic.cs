using GUI_20212202_IJA9WQ.UserControlls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_IJA9WQ.Logic
{
    public class ViewLogic : IViewLogic
    {
        public object View { get; set; }
        public ViewLogic()
        {
            View = new MenuUC();
        }
        public void ChangeView(string view)
        {
            switch (view)
            {
                case "game":
                    View = new GameUC();
                    break;
                case "menu":
                    View = new MenuUC();
                    break;
                default:
                    break;
            }
        }
    }
}
