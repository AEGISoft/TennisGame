using Xunit;

namespace Tennis.Test
{
    public partial class WhenFollowingAnExampleGame
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
                game.WonPoint(rallies[rally].WonByPlayer);
                Assert.Equal(rallies[rally].ExpectedScore, game.GetScore());
            }
        }
    }
}
