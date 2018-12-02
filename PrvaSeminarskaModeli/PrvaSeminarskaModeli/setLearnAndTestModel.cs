using System;
using System.Collections.Generic;
using System.Text;

namespace PrvaSeminarskaModeli
{
    class setLearnAndTestModel
    {
        private List<List<String>> _games { get; set;}
        private List<List<String>> _gamesLearn { get; set; }
        private List<List<String>> _gamesTest { get; set; }

        private int _nStatistic { get; set; }
        private Boolean _winnerIsHome { get; set; }
        private int _learnTestRatio { get; set; }

        public setLearnAndTestModel(List<List<String>> games, int learnTestRatio, int nStatistics, bool winnerIsHome)
        {
            _games = games;
            _learnTestRatio = learnTestRatio;
            _nStatistic = nStatistics;
            _winnerIsHome = winnerIsHome;
            _gamesLearn = new List<List<string>>();
            _gamesTest = new List<List<string>>();
        }

        public void setRandomRatio(List<List<String>> games)
        {
            Random rnd = new Random();
            List<int> testIndexes = new List<int>();
            double learn = 100 - _learnTestRatio;
            learn /= 100;
            int nTestGames = Convert.ToInt32(Math.Floor(games.Count * learn));

            _gamesTest.Add(games[0]);
            for (int i = nTestGames; i >= 0; i--)
            {
                int index = rnd.Next(0, games.Count);
                if(!testIndexes.Contains(index))
                {
                    testIndexes.Add(index);
                }
                else
                {
                    i++;
                }
            }

            for (int i = 0; i < games.Count; i++)
            {
                if(testIndexes.Contains(i))
                {
                    _gamesTest.Add(games[i]);
                }else
                {
                    _gamesLearn.Add(games[i]);
                }
            }
            
        }

        public void saveFiles()
        {
            GameStatistics allGames = new GameStatistics(_games, _nStatistic, _winnerIsHome);
            allGames.parseGames();
            setRandomRatio(allGames._ParsedGames);

            DocumnetReader reader = new DocumnetReader();
            reader.saveFile(_gamesLearn, "Learn.txt");

            reader.saveFile(_gamesTest, "Test.txt");
        }
    }
}
