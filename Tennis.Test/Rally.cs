namespace Tennis.Test
{
    public partial class WhenFollowingAnExampleGame
    {
        private class Rally
        {
            public Rally(Player scoringPlayer, string expectedScore)
            {
                WonByPlayer = scoringPlayer;
                ExpectedScore = expectedScore;
            }

            public Player WonByPlayer { get; internal set; }
            public string ExpectedScore { get; internal set; }
        }
    }
}
