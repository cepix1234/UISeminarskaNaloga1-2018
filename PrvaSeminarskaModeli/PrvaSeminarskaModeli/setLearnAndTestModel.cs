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

        public void setRandomRatio()
        {
            Random rnd = new Random();
            List<int> testIndexes = new List<int>();
            int nTestGames = _games.Count / _learnTestRatio;

            for (int i = nTestGames; i >= 0; i--)
            {
                int index = rnd.Next(0, _games.Count);
                if(!testIndexes.Contains(index))
                {
                    testIndexes.Add(index);
                }
                else
                {
                    i++;
                }
            }

            for (int i = 0; i < _games.Count; i++)
            {
                if(testIndexes.Contains(i))
                {
                    _gamesTest.Add(_games[i]);
                }else
                {
                    _gamesLearn.Add(_games[i]);
                }
            }

            
        }

        public void saveFiles()
        {
            GameStatistics gamesLear = new GameStatistics(_gamesLearn, _nStatistic, _winnerIsHome);
            gamesLear.parseGames();
            DocumnetReader reader = new DocumnetReader();
            reader.saveFile(gamesLear._ParsedGames, "Learn.txt");

            GameStatistics gamesTest = new GameStatistics(_gamesTest, _nStatistic, _winnerIsHome);
            gamesTest.parseGames();
            reader.saveFile(gamesTest._ParsedGames, "Test.txt");
        }
    }
}
