using System;
using Xunit;

namespace Tennis.Test
{
    public class VerifyTennisGameScore
    {
        [Fact]
        public void ExampleGame()
        {
            TennisGame game = new TennisGame("player1", "player2");
            string[] points = { "player1", "player1", "player2", "player2", "player1", "player1" };
            string[] expected_scores = { "Fifteen-Love", "Thirty-Love", "Thirty-Fifteen", "Thirty-All", "Forty-Thirty", "Win for Player 1" };

            for (int i = 0; i < points.Length; i++)
            {
                game.WonPoint(points[i]);
                Assert.Equal(expected_scores[i], game.GetScore());
            }
        }

        [Theory]
        [InlineData(0, 0, "Love-All")]
        [InlineData(1, 1, "Fifteen-All")]
        [InlineData(2, 2, "Thirty-All")]
        [InlineData(3, 3, "Forty-All")]
        [InlineData(4, 4, "Deuce")]
        [InlineData(1, 0, "Fifteen-Love")]
        [InlineData(0, 1, "Love-Fifteen")]
        [InlineData(2, 0, "Thirty-Love")]
        [InlineData(0, 2, "Love-Thirty")]
        [InlineData(3, 0, "Forty-Love")]
        [InlineData(0, 3, "Love-Forty")]
        [InlineData(4, 0, "Win for Player 1")]
        [InlineData(0, 4, "Win for Player 2")]
        [InlineData(2, 1, "Thirty-Fifteen")]
        [InlineData(1, 2, "Fifteen-Thirty")]
        [InlineData(3, 1, "Forty-Fifteen")]
        [InlineData(1, 3, "Fifteen-Forty")]
        [InlineData(4, 1, "Win for Player 1")]
        [InlineData(1, 4, "Win for Player 2")]
        [InlineData(3, 2, "Forty-Thirty")]
        [InlineData(2, 3, "Thirty-Forty")]
        [InlineData(4, 2, "Win for Player 1")]
        [InlineData(2, 4, "Win for Player 2")]
        [InlineData(4, 3, "Advantage Player 1")]
        [InlineData(3, 4, "Advantage Player 2")]
        [InlineData(5, 4, "Advantage Player 1")]
        [InlineData(4, 5, "Advantage Player 2")]
        [InlineData(15, 14, "Advantage Player 1")]
        [InlineData(14, 15, "Advantage Player 2")]
        [InlineData(6, 4, "Win for Player 1")]
        [InlineData(4, 6, "Win for Player 2")]
        [InlineData(16, 14, "Win for Player 1")]
        [InlineData(14, 16, "Win for Player 2")]
        public void TestScores(int score1, int score2, string score)
        {
            TennisGame game = new TennisGame("player1", "player2");
            int highestScore = Math.Max(score1, score2);
            for (int i = 0; i < highestScore; i++)
            {
                if (i < score1)
                    game.WonPoint("player1");
                if (i < score2)
                    game.WonPoint("player2");
            }

            Assert.Equal(game.GetScore(), score);

        }
    }
}
