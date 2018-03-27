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
            if (ScoresAreEqual())           return EqualScore();
            else if (APlayerHasWon())       return WinningScore();
            else if (APlayerHasAdvantage()) return AdvantageScore();
            else                            return MidRallyScore();
        }

        #region private Parts
        private bool ScoresAreEqual()       { return _player1.ScoreIsEqualTo(_player2); }
        private bool APlayerHasWon()        { return _player1.HasWonFrom(_player2) || _player2.HasWonFrom(_player1); }
        private bool APlayerHasAdvantage()  { return _player1.HasAdvantageOver(_player2) || _player2.HasAdvantageOver(_player1); }

        private string MidRallyScore()
        {
            return TranslateScoreFrom(_player1.GamePoints) + "-" + TranslateScoreFrom(_player2.GamePoints);
        }

        private static string TranslateScoreFrom(int gamePoints)
        {
            switch (gamePoints)
            {
                case 0: return "Love"; 
                case 1: return "Fifteen"; 
                case 2: return "Thirty"; 
                case 3: return "Forty";
                default: return "";
            }
        }

        private string AdvantageScore()
        {
            if (_player1.HasAdvantageOver(_player2))
                 return "Advantage Player 1";
            else return "Advantage Player 2";
        }

        private string WinningScore()
        {
            if (_player1.HasWonFrom(_player2))
                 return "Win for Player 1";
            else return "Win for Player 2";
        }

        private string EqualScore()
        {
            if (_player1.GamePoints > 3)
                 return "Deuce";
            else return TranslateScoreFrom(_player1.GamePoints) + "-All";
        }
        #endregion
    }
}
