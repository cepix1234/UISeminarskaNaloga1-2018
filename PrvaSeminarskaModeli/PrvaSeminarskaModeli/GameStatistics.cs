using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrvaSeminarskaModeli
{
    class GameStatistics
    {
        List<List<String>> _games;
        Dictionary<String, Team> _teams;
        private int _nStatistic;
        private bool _winnerIsHome;

        public List<List<String>> _ParsedGames { get; set; }


        public GameStatistics(List<List<String>> games, int nStatistics, bool winnerIsHome)
        {
            _games = games;
            _teams = new Dictionary<string, Team>();
            _ParsedGames = new List<List<string>>();
            _nStatistic = nStatistics;
            _winnerIsHome = winnerIsHome;
            setParsedGamesHeader();
        }


        public void parseGames()
        {
            foreach(List<String> game in _games)
            {
                var home = game.Skip(2).Take(15).ToArray();
                var away = game.Skip(17).Take(15).ToArray();

                if (!_teams.Keys.Contains(home[0]))
                {
                    _teams[home[0]] = new Team(home.ToList(), _nStatistic);
                } else
                {
                    _teams[home[0]].newGame(home.ToList());
                }

                if (!_teams.Keys.Contains(away[0]))
                {
                    _teams[away[0]] = new Team(away.ToList(), _nStatistic);
                }
                else
                {
                    _teams[away[0]].newGame(away.ToList());
                }
                setParsedGames(_teams[home[0]], _teams[away[0]], getWinner(home, away));
            }
        }

        private double getWinner(String[] home, String[] away)
        {
            if(_winnerIsHome)
            {
                if(Convert.ToInt32(home[1]) >= Convert.ToInt32(away[1]))
                {
                    return 1;
                }
            }else
            {
                return Convert.ToInt32(home[1]) - Convert.ToInt32(away[1]);
            }
            return 0;
        }

        private void setParsedGames(Team home, Team away, double winner)
        {
            List<String> game = new List<string>();

            if(_nStatistic > 0)
            {
                //home
                game.Add('\"'+home.teamName+'\"');
                game.Add(home.allPoints.ToString());
                game.Add(home.allPointForN.ToString());
                game.Add(home.povpTwoPoints.ToString());
                game.Add(home.povpTwoPointsForN.ToString());
                game.Add(home.povpTreePoints.ToString());
                game.Add(home.povpTreePointsForN.ToString());
                game.Add(home.povpFreeThrows.ToString());
                game.Add(home.povpFreeThrowsForN.ToString());
                game.Add(home.attackJumps.ToString());
                game.Add(home.attackJumpsForN.ToString());
                game.Add(home.defendJumpos.ToString());
                game.Add(home.defendJumposForN.ToString());
                game.Add(home.assissts.ToString());
                game.Add(home.assisstsForN.ToString());
                game.Add(home.stolenBalls.ToString());
                game.Add(home.stolenBallsForN.ToString());
                game.Add(home.lostBalls.ToString());
                game.Add(home.lostBallsForN.ToString());
                game.Add(home.blockages.ToString());
                game.Add(home.blockagesForN.ToString());
                game.Add(home.personalFouls.ToString());
                game.Add(home.personalFoulsForN.ToString());

                //away
                game.Add('\"'+away.teamName+'\"');
                game.Add(away.allPoints.ToString());
                game.Add(away.allPointForN.ToString());
                game.Add(away.povpTwoPoints.ToString());
                game.Add(away.povpTwoPointsForN.ToString());
                game.Add(away.povpTreePoints.ToString());
                game.Add(away.povpTreePointsForN.ToString());
                game.Add(away.povpFreeThrows.ToString());
                game.Add(away.povpFreeThrowsForN.ToString());
                game.Add(away.attackJumps.ToString());
                game.Add(away.attackJumpsForN.ToString());
                game.Add(away.defendJumpos.ToString());
                game.Add(away.defendJumposForN.ToString());
                game.Add(away.assissts.ToString());
                game.Add(away.assisstsForN.ToString());
                game.Add(away.stolenBalls.ToString());
                game.Add(away.stolenBallsForN.ToString());
                game.Add(away.lostBalls.ToString());
                game.Add(away.lostBallsForN.ToString());
                game.Add(away.blockages.ToString());
                game.Add(away.blockagesForN.ToString());
                game.Add(away.personalFouls.ToString());
                game.Add(away.personalFoulsForN.ToString());

                //winner
                game.Add(winner.ToString());
            }else
            {
                //home
                game.Add('\"'+home.teamName+'\"');
                game.Add(home.allPoints.ToString());
                game.Add(home.povpTwoPoints.ToString());
                game.Add(home.povpTreePoints.ToString());
                game.Add(home.povpFreeThrows.ToString());
                game.Add(home.attackJumps.ToString());
                game.Add(home.defendJumpos.ToString());
                game.Add(home.assissts.ToString());
                game.Add(home.stolenBalls.ToString());
                game.Add(home.lostBalls.ToString());
                game.Add(home.blockages.ToString());
                game.Add(home.personalFouls.ToString());

                //away
                game.Add('\"'+away.teamName+'\"');
                game.Add(away.allPoints.ToString());
                game.Add(away.povpTwoPoints.ToString());
                game.Add(away.povpTreePoints.ToString());
                game.Add(away.povpFreeThrows.ToString());
                game.Add(away.attackJumps.ToString());
                game.Add(away.defendJumpos.ToString());
                game.Add(away.assissts.ToString());
                game.Add(away.stolenBalls.ToString());
                game.Add(away.lostBalls.ToString());
                game.Add(away.blockages.ToString());
                game.Add(away.personalFouls.ToString());

                //winner
                game.Add(winner.ToString());
            }

            _ParsedGames.Add(game);
        }

        private void setParsedGamesHeader()
        {
            List<String> game = new List<string>();

            if (_nStatistic > 0)
            {
                //home
                game.Add("\"HOME\"");
                game.Add("\"All points\"");
                game.Add("\"All points for last " + _nStatistic+ " games\"");
                game.Add("\"Two points\"");
                game.Add("\"Two points for last " + _nStatistic+ " games\"");
                game.Add("\"Thre points\"");
                game.Add("\"Thre points for last " + _nStatistic+ " games\"");
                game.Add("\"Free throws\"");
                game.Add("\"Free points for last " + _nStatistic + " games\"");
                game.Add("\"Attack jumps\"");
                game.Add("\"Attack jumps for last " + _nStatistic + " games\"");
                game.Add("\"Defending jumps\"");
                game.Add("\"Defending jumps for last " + _nStatistic + " games\"");
                game.Add("\"Assissts\"");
                game.Add("\"Assissts for last " + _nStatistic + " games\"");
                game.Add("\"Stolen balls\"");
                game.Add("\"Stolen balls for last " + _nStatistic + " games\"");
                game.Add("\"Lost balls\"");
                game.Add("\"Lost balls for last " + _nStatistic + " games\"");
                game.Add("\"Blockages fouls\"");
                game.Add("\"Blockages fouls for last " + _nStatistic + " games\"");
                game.Add("\"Personal fouls\"");
                game.Add("\"Personal fouls for last " + _nStatistic + " games\"");

                //away
                game.Add("\"AWAY\"");
                game.Add("\"All points\"");
                game.Add("\"All points for last " + _nStatistic + " games\"");
                game.Add("\"Two points\"");
                game.Add("\"Two points for last " + _nStatistic + " games\"");
                game.Add("\"Thre points\"");
                game.Add("\"Thre points for last " + _nStatistic + " games\"");
                game.Add("\"Free throws\"");
                game.Add("\"Free points for last " + _nStatistic + " games\"");
                game.Add("\"Attack jumps\"");
                game.Add("\"Attack jumps for last " + _nStatistic + " games\"");
                game.Add("\"Defending jumps\"");
                game.Add("\"Defending jumps for last " + _nStatistic + " games\"");
                game.Add("\"Assissts\"");
                game.Add("\"Assissts for last " + _nStatistic + " games\"");
                game.Add("\"Stolen balls\"");
                game.Add("\"Stolen balls for last " + _nStatistic + " games\"");
                game.Add("\"Lost balls\"");
                game.Add("\"Lost balls for last " + _nStatistic + " games\"");
                game.Add("\"Blockages fouls\"");
                game.Add("\"Blockages fouls for last " + _nStatistic + " games\"");
                game.Add("\"Personal fouls\"");
                game.Add("\"Personal fouls for last " + _nStatistic + " games\"");

                //winner
                game.Add("\"WINNER\"");
            }
            else
            {
                //home
                game.Add("\"HOME\"");
                game.Add("\"All points\"");
                game.Add("\"Two points\"");
                game.Add("\"Thre points\"");
                game.Add("\"Free throws\"");
                game.Add("\"Attack jumps\"");
                game.Add("\"Defending jumps\"");
                game.Add("\"Assissts\"");
                game.Add("\"Stolen balls\"");
                game.Add("\"Lost balls\"");
                game.Add("\"Blockages fouls\"");
                game.Add("\"Personal fouls\"");

                //away
                game.Add("\"AWAY\"");
                game.Add("\"All points\"");
                game.Add("\"Two points\"");
                game.Add("\"Thre points\"");
                game.Add("\"Free throws\"");
                game.Add("\"Attack jumps\"");
                game.Add("\"Defending jumps\"");
                game.Add("\"Assissts\"");
                game.Add("\"Stolen balls\"");
                game.Add("\"Lost balls\"");
                game.Add("\"Blockages fouls\"");
                game.Add("\"Personal fouls\"");

                //winner
                game.Add("\"WINNER\"");
            }

            _ParsedGames.Add(game);
        }
    }
}
