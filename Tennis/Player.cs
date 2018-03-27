namespace Tennis
{
    internal class Player
    {
        #region construction
        public string Name { get; }
        public Player(string playerName)
        {
            this.Name = playerName;
            this.GamePoints = 0;
        }
        #endregion

        #region internal interface
        internal int GamePoints { get; private set; }

        internal void ScoredPointByWinningRally()
        {
            GamePoints++;
        }

        internal bool ScoreIsEqualTo(Player player2)
        {
            return this.GamePoints == player2.GamePoints;
        }

        internal bool HasAdvantageOrWinsOver(Player player2)
        {
            return this.GamePoints >= 4;
        }

        internal bool HasWonFrom(Player player2)
        {
            return this.GamePoints >= 4 & GamePoints > player2.GamePoints+1;
        }

        internal bool HasAdvantageOver(Player player2)
        {
            return this.GamePoints >= 4 & GamePoints == player2.GamePoints+1 ;
        }
        #endregion
    }
}
