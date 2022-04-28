namespace GUI_20212202_IJA9WQ.Logic
{
    public interface IViewLogic
    {
        object View { get; set; }

        void ChangeView(string view);
    }
}