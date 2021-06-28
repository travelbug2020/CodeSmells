using System;
using Xunit;
using TicTacToe;
using static TicTacToe.Player;
using static TicTacToe.Position;

namespace TicTacToeTests
{
    public class GameShould
    {
        private Game game;

        public GameShould()
        {
           game = new Game();
        }

        [Fact]
        public void NotAllowPlayerOToPlayFirst()
        {
            Action wrongPlay = () => game.Play(Tile.From('O', 0, 0));

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid first player", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerXToPlayTwiceInARow()
        {
            game.Play(Tile.From('X', 0, 0));
            
            Action wrongPlay = () => game.Play(Tile.From('X', 1, 0));

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid next player", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerToPlayInLastPlayedPosition()
        {
            game.Play(Tile.From('X', 0, 0));

            Action wrongPlay = () => game.Play(Tile.From('O', 0, 0));

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid position", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerToPlayInAnyPlayedPosition()
        {
            game.Play(Tile.From('X', 0, 0));
            game.Play(Tile.From('O', 1, 0));

            Action wrongPlay = () => game.Play(Tile.From('X', 0, 0));

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid position", exception.Message);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInTopRow()
        {
            game.Play(new Tile(BottomLeft, X));
            game.Play(new Tile(BottomMiddle, O));
            game.Play(new Tile(CenterLeft, X));
            game.Play(new Tile(CenterMiddle, O));
            game.Play(new Tile(TopLeft, X));

            var winner = game.Winner();

            Assert.Equal(X, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInTopRow()
        {
            game.Play(new Tile(TopRight, X));
            game.Play(new Tile(BottomLeft, O));
            game.Play(new Tile(BottomMiddle, X));
            game.Play(new Tile(CenterLeft, O));
            game.Play(new Tile(CenterMiddle, X));
            game.Play(new Tile(TopLeft, O));

            var winner = game.Winner();

            Assert.Equal(O, winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInMiddleRow()
        {
            game.Play(Tile.From('X', 1, 0));
            game.Play(Tile.From('O', 0, 0));
            game.Play(Tile.From('X', 1, 1));
            game.Play(Tile.From('O', 0, 1));
            game.Play(Tile.From('X', 1, 2));

            var winner = game.Winner();

            Assert.Equal(X, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInMiddleRow()
        {
            game.Play(Tile.From('X', 0, 0));
            game.Play(Tile.From('O', 1, 0));
            game.Play(Tile.From('X', 2, 0));
            game.Play(Tile.From('O', 1, 1));
            game.Play(Tile.From('X', 2, 1));
            game.Play(Tile.From('O', 1, 2));

            var winner = game.Winner();

            Assert.Equal(O, winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInBottomRow()
        {
            game.Play(Tile.From('X', 2, 0));
            game.Play(Tile.From('O', 0, 0));
            game.Play(Tile.From('X', 2, 1));
            game.Play(Tile.From('O', 0, 1));
            game.Play(Tile.From('X', 2, 2));

            var winner = game.Winner();

            Assert.Equal(X, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInBottomRow()
        {
            game.Play(Tile.From('X', 0, 0));
            game.Play(Tile.From('O', 2, 0));
            game.Play(Tile.From('X', 1, 0));
            game.Play(Tile.From('O', 2, 1));
            game.Play(Tile.From('X', 1, 1));
            game.Play(Tile.From('O', 2, 2));

            var winner = game.Winner();

            Assert.Equal(O, winner);
        }
    }
}
