
using System;

namespace Tennis
{
    public class TennisGame
    {

        private Player _player1;
        private Player _player2;

        public TennisGame(string player1Name, string player2Name)
        {
            _player1 = new Player(player1Name);
            _player2 = new Player(player2Name);
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1.Name)
                _player1.ScoredPointByWinningRally();
            else
                _player2.ScoredPointByWinningRally();
        }

        public string GetScore()
        {
            string score = "";
            if (_player1.ScoreIsEqualTo(_player2))
            {
                score = EqualScore();
            }
            else if (_player1.HasWonFrom(_player2) || _player2.HasWonFrom(_player1))
            {
                score = AdvantageOrWinningScore();
            }
            else if (_player1.HasAdvantageOver(_player2) || _player2.HasAdvantageOver(_player1))
            {
                score = AdvantageOrWinningScore();
            }
            else
            {
                score = MidRallyScore();
            }
            return score;
        }

        private string MidRallyScore()
        {
            string tempscore = "";
            int s = 0;
            for (int i = 1; i < 3; i++)
            {
                if (i == 1) s = _player1.Score;
                else { tempscore += "-"; s = _player2.Score; }
                switch (s)
                {
                    case 0: tempscore += "Love"; break;
                    case 1: tempscore += "Fifteen"; break;
                    case 2: tempscore += "Thirty"; break;
                    case 3: tempscore += "Forty"; break;
                }
            }
            return tempscore;
        }

        private string AdvantageOrWinningScore()
        {
            string score;
            int minRes = _player1.Score - _player2.Score;
            if (minRes == 1) score = "Advantage Player 1";
            else if (minRes == -1) score = "Advantage Player 2";
            else if (minRes >= 2) score = "Win for Player 1";
            else score = "Win for Player 2";
            return score;
        }

        private string EqualScore()
        {
            string score;
            switch (_player1.Score)
            {
                case 0: score = "Love-All"; break;
                case 1: score = "Fifteen-All"; break;
                case 2: score = "Thirty-All"; break;
                case 3: score = "Forty-All"; break;
                default: score = "Deuce"; break;
            }

            return score;
        }
    }
}
