using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PrvaSeminarskaModeli
{
    class DocumnetReader
    {
        public List<List<String>> _games { get; set; }
        string _document;

        public DocumnetReader (string document)
        {
            _games = new List<List<string>>();
            _document = document;
        }

        public void setGames(List<List<String>> games)
        {
            _games = games;
        }

        public void readFile ()
        {
            using (StreamReader file = new StreamReader(_document))
            {
                String line;
                int lineNumber = 0;

                while ((line = file.ReadLine()) != null)
                {
                    if (lineNumber > 0) //skip first line
                    {
                        line = line.Replace("\"", "");
                        List<String> lineList = new List<String>(line.Split(","));
                        _games.Add(lineList);
                    }
                    lineNumber++;
                }
            }
        }

        public void saveFile(List<List<String>> games)
        {
            _document = _document.Replace(".txt", "-Output.txt");

            using ( StreamWriter file = new StreamWriter(_document))
            {
                foreach (List<String> game in games)
                {
                    String line = "";
                    foreach (String value in game)
                    {
                        line += value + ",";
                    }
                    line = line.Remove(line.Length - 1);
                    file.WriteLine(line);
                }
            } 
        }
    }
}
