using System;

namespace Tennis
{
    internal class Player
    {
        #region construction
        public string Name { get; }
        public Player(string playerName)
        {
            this.Name = playerName;
            this.Score = 0;
        }
        #endregion

        #region published interface
        public int Score { get; private set; }

        public void ScoredPointByWinningRally()
        {
            Score++;
        }

        internal bool ScoreIsEqualTo(Player player2)
        {
            return this.Score == player2.Score;
        }

        internal bool HasAdvantageOrWinsOver(Player player2)
        {
            return this.Score >= 4;
        }

        internal bool HasWonFrom(Player player2)
        {
            return this.Score >= 4 & Score > player2.Score+1;
        }

        internal bool HasAdvantageOver(Player player2)
        {
            return this.Score >= 4 & Score == player2.Score+1 ;
        }
        #endregion
    }
}
