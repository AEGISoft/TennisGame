using System;

namespace Tennis
{
    public class TennisGame
    {
        #region construction
        readonly private Player player1;
        readonly private Player player2;
        public TennisGame(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }
        #endregion

        #region published interface
        public void RallyWonBy(Player player)
        {
            player.ScoredPointByWinningRally();
        }

        public string GetScore()
        {
            if (APlayerHasWon()) return WinningScore(); 
            else if (ScoresAreEqual()) return EqualScore();
            else if (APlayerHasAdvantage()) return AdvantageScore();
            else return MidRallyScore();
        }
        #endregion

        #region private parts
        private bool APlayerHasWon()
        {
            return this.player1.HasWonOver(this.player2) 
                || this.player2.HasWonOver(this.player1);
        }

        private bool APlayerHasAdvantage()
        {
            return this.player1.HasAdvantageOver(this.player2)
                || this.player2.HasAdvantageOver(this.player1);
        }

        private bool ScoresAreEqual()
        {
            return this.player1.NrOfRaliesWon == this.player2.NrOfRaliesWon;
        }

        private string MidRallyScore()
        {
            return TransformToScore(this.player1.NrOfRaliesWon) + "-" + TransformToScore(this.player2.NrOfRaliesWon);
        }

        private static string TransformToScore(int ralliesWon)
        {
            string scorepart = "";
            switch (ralliesWon)
            {
                case 0: scorepart = "Love"; break;
                case 1: scorepart = "Fifteen"; break;
                case 2: scorepart = "Thirty"; break;
                case 3: scorepart = "Forty"; break;
            }

            return scorepart;
        }

        private string AdvantageScore()
        {
            if (player1.HasAdvantageOver(player2))
                 return "Advantage Player 1";
            else return "Advantage Player 2";
        }

        private string WinningScore()
        {
            if (player1.HasWonOver(player2))
                 return "Win for Player 1";
            else return "Win for Player 2";
        }

        private string EqualScore()
        {
            if (this.player1.NrOfRaliesWon > 3)
                return "Deuce";
            else
                return TransformToScore(player1.NrOfRaliesWon) + "-All";
        }
        #endregion
    }
}
