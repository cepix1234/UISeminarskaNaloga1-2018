using System;
using System.Collections.Generic;
using System.Text;

namespace PrvaSeminarskaModeli
{
    class Team
    {
        public int allPoints { get; set; }
        public double povpTwoPoints { get; set; }
        public double povpTreePoints { get; set; }
        public double povpFreeThrows { get; set; }
        public int attackJumps { get; set; }
        public int defendJumpos { get; set; }
        public int assissts { get; set; }
        public int stolenBalls { get; set; }
        public int lostBalls { get; set; }
        public int blockages { get; set; }
        public int personalFouls { get; set; }

        //all stats bot n games before
        public int allPointForN { get; set; }
        public double povpTwoPointsForN { get; set; }
        public double povpTreePointsForN { get; set; }
        public double povpFreeThrowsForN { get; set; }
        public int attackJumpsForN { get; set; }
        public int defendJumposForN { get; set; }
        public int assisstsForN { get; set; }
        public int stolenBallsForN { get; set; }
        public int lostBallsForN { get; set; }
        public int blockagesForN { get; set; }
        public int personalFoulsForN { get; set; }

        public string teamName;

        private int numbGames;
        private List<List<String>> _games;
        private int _nStatistic;



        public Team (List<String> game, int nStatistic)
        {
            _games = new List<List<string>>();
            _games.Add(game);
            numbGames = 1;
            _nStatistic = nStatistic;
            setToZero();
            teamName = game[0];
        }

        public void newGame(List<String> game)
        {
            numbGames++;
            _games.Add(game);
            if(_nStatistic != 0)
            {
                calcualteStatsForN();
            }
            calcualteStats();
        }

        private void calcualteStatsForN ()
        {
            if(_games.Count >= _nStatistic)
            {
                allPointForN = 0;
                povpTwoPointsForN = 0;
                povpTreePointsForN = 0;
                povpFreeThrowsForN = 0;
                attackJumpsForN = 0;
                defendJumposForN = 0;
                assisstsForN = 0;
                stolenBallsForN = 0;
                lostBallsForN = 0;
                blockagesForN = 0;
                personalFoulsForN = 0;

                for (int i = _games.Count-1; i >= _games.Count-_nStatistic; i--)
                {
                    allPointForN += Convert.ToInt32(_games[i][1] );
                    povpTwoPointsForN += Convert.ToDouble(_games[i][2])/ Convert.ToDouble(_games[i][3]);
                    povpTreePointsForN += Convert.ToDouble(_games[i][4])/ Convert.ToDouble(_games[i][5]);
                    povpFreeThrowsForN += Convert.ToDouble(_games[i][6])/ Convert.ToDouble(_games[i][7]);
                    attackJumpsForN += Convert.ToInt32(_games[i][8]);
                    defendJumposForN += Convert.ToInt32(_games[i][9]);
                    assisstsForN += Convert.ToInt32(_games[i][10]);
                    stolenBallsForN += Convert.ToInt32(_games[i][11]);
                    lostBallsForN += Convert.ToInt32(_games[i][12]);
                    blockagesForN += Convert.ToInt32(_games[i][13]);
                    personalFoulsForN += Convert.ToInt32(_games[i][14]);
                }

                allPointForN /= _nStatistic;
                povpTwoPointsForN /= _nStatistic;
                povpTreePointsForN /= _nStatistic;
                povpFreeThrowsForN /= _nStatistic;
                attackJumpsForN /= _nStatistic;
                defendJumposForN /= _nStatistic;
                assisstsForN /= _nStatistic;
                stolenBallsForN /= _nStatistic;
                lostBallsForN /= _nStatistic;
                blockagesForN /= _nStatistic;
                personalFoulsForN /= _nStatistic;
            }
        }

        private void calcualteStats()
        {
            allPoints = 0;
            povpTwoPoints = 0;
            povpTreePoints = 0;
            povpFreeThrows = 0;
            attackJumps = 0;
            defendJumpos = 0;
            assissts = 0;
            stolenBalls = 0;
            lostBalls = 0;
            blockages = 0;
            personalFouls = 0;

            foreach(List<String> game in _games)
            {
                allPoints += Convert.ToInt32(game[1]);
                povpTwoPoints+= Convert.ToDouble(game[2])/ Convert.ToDouble(game[3]);
                povpTreePoints += Convert.ToDouble(game[4])/ Convert.ToDouble(game[5]);
                povpFreeThrows+= Convert.ToDouble(game[6])/ Convert.ToDouble(game[7]);
                attackJumps += Convert.ToInt32(game[8]);
                defendJumpos += Convert.ToInt32(game[9]);
                assissts += Convert.ToInt32(game[10]);
                stolenBalls += Convert.ToInt32(game[11]);
                lostBalls += Convert.ToInt32(game[12]);
                blockages += Convert.ToInt32(game[13]);
                personalFouls += Convert.ToInt32(game[14]);
            }

            allPoints /= numbGames;
            povpTwoPoints /= numbGames;
            povpTreePoints /= numbGames;
            povpFreeThrows /= numbGames;
            attackJumps /= numbGames;
            defendJumpos /= numbGames;
            assissts/= numbGames;
            stolenBalls /= numbGames;
            lostBalls /= numbGames;
            blockages /= numbGames;
            personalFouls /= numbGames;
        }

        private void setToZero()
        {
            allPointForN = 0;
            povpTwoPointsForN = 0;
            povpTreePointsForN = 0;
            povpFreeThrowsForN = 0;
            attackJumpsForN = 0;
            defendJumposForN = 0;
            assisstsForN = 0;
            stolenBallsForN = 0;
            lostBallsForN = 0;
            blockagesForN = 0;
            personalFoulsForN = 0;


            allPoints = 0;
            povpTwoPoints = 0;
            povpTreePoints = 0;
            povpFreeThrows = 0;
            attackJumps = 0;
            defendJumpos = 0;
            assissts = 0;
            stolenBalls = 0;
            lostBalls = 0;
            blockages = 0;
            personalFouls = 0;
        }
    }
}
