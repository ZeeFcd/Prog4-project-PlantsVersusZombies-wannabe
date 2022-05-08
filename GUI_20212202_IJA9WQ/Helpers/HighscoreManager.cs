using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_IJA9WQ.Helpers
{
    class HighscoreManager
    {
        List<(int, string, string, string)> highscores;

        public List<(int,string,string,string)> Highscores { get => highscores;}

        public HighscoreManager()
        {
            ReadHighscoreFromText();
        }

        private void ReadHighscoreFromText() 
        {
            highscores = new List<(int, string, string, string)>();
            if (File.Exists("highscores.txt"))
            {
                string[] highscoreLines = File.ReadAllLines("highscores.txt");
                foreach (var score in highscoreLines)
                {
                    string[] temp = score.Split(',');
                    (int, string, string, string) highscore = (int.Parse(temp[0]), temp[1], temp[2], temp[3]);
                    highscores.Add(highscore);
                }
            }

        }

        public void WriteHighscoreToText()
        {
            List<string> highscoresString = new List<string>();
            foreach (var score in highscores)
            {
                string temp = score.Item1 + ',' + score.Item2 + ',' + score.Item3 + ',' + score.Item4;
                highscoresString.Add(temp);
            }
            File.WriteAllLines("highscores.txt", highscoresString);
        }

        public void Add((int, string, string, string) value) 
        {
            highscores.Add(value);
            highscores.Sort();
        }
    }
}
