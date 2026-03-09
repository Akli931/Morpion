using Morpion;
using Morpion.Tests;
using System;
using System.Collections.Generic;
using System.Text;
using static Morpion.Player;

namespace TestProjectMorpion
{
    public class GameTests
    {
        [Fact]
    
        public async Task GameShouldEndWhenPlayerXWins()

        {

            var playerX = new FakePlayer('X', new[]
            {
                new PlayerMove(0, 0),
                new PlayerMove(0, 1),
                new PlayerMove(0, 2)
            });

            var playerO = new FakePlayer('O', new[]
            {
                new PlayerMove(1, 0),
                new PlayerMove(1, 1)
            });

            var game = new Game(playerX, playerO);


            await game.StartAsync();



            Assert.NotNull(game.Winner);
            Assert.Equal('X', game.Winner.Symbol);
        }
    }
}
