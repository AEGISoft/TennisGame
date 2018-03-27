using System;

namespace Tennis
{

    public class Player
    {
        #region construction
        public Player(string playerName)
        {
            this.Name = playerName;
            this.NrOfRaliesWon = 0;
        }
        #endregion

        #region published interface
        public string Name { get; private set; }
        public int NrOfRaliesWon { get; private set; }

        public void ScoredPointByWinningRally()
        {
            this.NrOfRaliesWon++;
        }

        public bool HasAdvantageOver(Player otherPlayer)
        {
            return WonFourOrMoreRalies() & LeadingWithOnePointOver(otherPlayer);
        }

        public bool HasWonOver(Player otherPlayer)
        {
            return WonFourOrMoreRalies() & LeadingWithAtLeastTwoPointsOver(otherPlayer);
        }

        #endregion

        #region private parts
        private bool WonFourOrMoreRalies()
        {
            return this.NrOfRaliesWon >= 4;
        }

        private bool LeadingWithOnePointOver(Player otherPlayer)
        {
            return this.NrOfRaliesWon - otherPlayer.NrOfRaliesWon == 1;
        }

        private bool LeadingWithAtLeastTwoPointsOver(Player otherPlayer)
        {
            return this.NrOfRaliesWon - otherPlayer.NrOfRaliesWon >= 2;
        }

        #endregion
    }
}