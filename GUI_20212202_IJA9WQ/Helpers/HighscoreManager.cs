using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_IJA9WQ.Helpers
{
    public class HighscoreManager
    {
        
        public static List<(string, string)> Highscores { get; private set; }
        public HighscoreManager()
        {
            ReadHighscoreFromText();
        }

        public void ReadHighscoreFromText() 
        {
            Highscores = new List<(string, string)>();
            if (File.Exists("highscores.txt"))
            {
                string[] highscoreLines = File.ReadAllLines("highscores.txt");
                foreach (var score in highscoreLines)
                {
                    string[] temp = score.Split(',');
                    (string, string) highscore = (temp[0], temp[1]);
                    Highscores.Add(highscore);
                }
            }

        }

        public void WriteHighscoreToText()
        {
            List<string> highscoresString = new List<string>();
            foreach (var score in Highscores)
            {
                string temp = score.Item1 + ',' + score.Item2 ;
                highscoresString.Add(temp);
            }
            File.WriteAllLines("highscores.txt", highscoresString);
        }

        public void Add( (string, string)value) 
        {
            Highscores.Add(value);
            Highscores = Highscores.OrderBy(x=>x.Item2).ToList();
        }
    }
}
