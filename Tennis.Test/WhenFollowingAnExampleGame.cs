using System;
using Xunit;

namespace Tennis.Test
{

    public class WhenFollowingAnExampleGame
    {
        [Fact]
        public void GameScoreShouldReflectTheScoresOfEachRally()
        {
            //Arrange
            var player1 = new Player("player1");
            var player2 = new Player("player2");
            TennisGame game = new TennisGame(player1, player2);

            Rally[] Rallies = {
                    new Rally(player1,"Fifteen-Love"),
                    new Rally(player1,"Thirty-Love"),
                    new Rally(player2,"Thirty-Fifteen"),
                    new Rally(player2,"Thirty-All"),
                    new Rally(player1,"Forty-Thirty"),
                    new Rally(player1,"Win for Player 1")
                };

            for (int rally = 0; rally < Rallies.Length; rally++)
            {
                //Act
                game.RallyWonBy(Rallies[rally].WonByPlayer);

                //Assert
                Assert.Equal(Rallies[rally].ExpectedScore, game.GetScore());
            }
        }

        private class Rally
        {
            public Rally(Player scoringPlayer, String score)
            {
                WonByPlayer = scoringPlayer;
                ExpectedScore = score;
            }
            public Player WonByPlayer { get; internal set; }
            public string ExpectedScore { get; internal set; }
        }

    }
}