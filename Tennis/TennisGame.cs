
namespace Tennis
{
    public class TennisGame
    {
        private int _score1 = 0;
        private int _score2 = 0;

        private string _player1Name = "";
        private string _player2Name = "";

        public TennisGame(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _score1++;
            else
                _score2++;
        }

        public string GetScore()
        {
            string score = "";
            if (_score1 == _score2)
            {
                score = EqualScore();
            }
            else if (_score1 >= 4 || _score2 >= 4)
            {
                score = AdvantageOrWinningScore();
            }
            else
            {
                string tempscore = "";
                int s = 0;
                for (int i = 1; i < 3; i++)
                {
                    if (i == 1) s = _score1;
                    else { tempscore += "-";s = _score2; }
                    switch (s)
                    {
                        case 0: tempscore += "Love";break;
                        case 1: tempscore += "Fifteen";break;
                        case 2: tempscore += "Thirty";break;
                        case 3: tempscore += "Forty";break;
                    }
                }
                score = tempscore;
            }
            return score;
        }

        private string AdvantageOrWinningScore()
        {
            string score;
            int minRes = _score1 - _score2;
            if (minRes == 1) score = "Advantage Player 1";
            else if (minRes == -1) score = "Advantage Player 2";
            else if (minRes >= 2) score = "Win for Player 1";
            else score = "Win for Player 2";
            return score;
        }

        private string EqualScore()
        {
            string score;
            switch (_score1)
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
