namespace GUI_20212202_IJA9WQ.Helpers
{
    public interface IHighscoreManager
    {
        void Add((string, string) value);
        void ReadHighscoreFromText();
        void WriteHighscoreToText();
    }
}