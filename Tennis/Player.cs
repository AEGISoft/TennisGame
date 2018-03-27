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
        #endregion
    }
}
