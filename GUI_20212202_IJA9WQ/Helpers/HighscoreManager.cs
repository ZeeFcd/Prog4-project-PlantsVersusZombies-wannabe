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
        List<(string, string, string)> highscores;

        public List<(string,string,string)> Highscores { get => highscores;}

        public HighscoreManager()
        {
            ReadHighscoreFromText();
        }

        private void ReadHighscoreFromText() 
        {
            highscores = new List<(string, string, string)>();
            if (File.Exists("highscores.txt"))
            {
                string[] highscoreLines = File.ReadAllLines("highscores.txt");
                foreach (var score in highscoreLines)
                {
                    string[] temp = score.Split(',');
                    (string, string, string) highscore = (temp[0], temp[1], temp[2]);
                    highscores.Add(highscore);
                }
            }

        }

        public void WriteHighscoreToText()
        {
            List<string> highscoresString = new List<string>();
            foreach (var score in highscores)
            {
                string temp = score.Item1 + ',' + score.Item2 + ',' + score.Item3;
                highscoresString.Add(temp);
            }
            File.WriteAllLines("highscores.txt", highscoresString);
        }

        public void Add( (string, string, string) value) 
        {
            highscores.Add(value);
            highscores=highscores.OrderBy(x=>x.Item2).ToList();
        }
    }
}
