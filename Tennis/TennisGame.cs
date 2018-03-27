﻿
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
        #endregion
    }
}
