using Xunit;

namespace Tennis.Test
{
    public class WhenFollowingAnExampleGame
    {
        [Fact]
        public void TheGameScoreShouldReflectTheScoresOfEachRally()
        {
            var player1 = new Player("player1");
            var player2 = new Player("player2");
            TennisGame game = new TennisGame(player1, player2);

            Rally[] rallies = {
                new Rally(player1, "Fifteen-Love"),
                new Rally(player1, "Thirty-Love"),
                new Rally(player2, "Thirty-Fifteen"),
                new Rally(player2, "Thirty-All"),
                new Rally(player1, "Forty-Thirty"),
                new Rally(player1, "Win for Player 1")
            };

            for (int rally = 0; rally < rallies.Length; rally++)
            {
                game.WonPoint(rallies[rally].WonByPlayer.Name);
                Assert.Equal(rallies[rally].ExpectedScore, game.GetScore());
            }
        }

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
