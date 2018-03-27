using Xunit;

namespace Tennis.Test
{
    public class WhenFollowingAnExampleGame
    {
        [Fact]
        public void TheGameScoreShouldReflectTheScoresOfEachRally()
        {
            TennisGame game = new TennisGame("player1", "player2");
            string[] points = { "player1", "player1", "player2", "player2", "player1", "player1" };
            string[] expected_scores = { "Fifteen-Love", "Thirty-Love", "Thirty-Fifteen", "Thirty-All", "Forty-Thirty", "Win for Player 1" };

            for (int rally = 0; rally < points.Length; rally++)
            {
                game.WonPoint(points[rally]);
                Assert.Equal(expected_scores[rally], game.GetScore());
            }
        }
    }
}
