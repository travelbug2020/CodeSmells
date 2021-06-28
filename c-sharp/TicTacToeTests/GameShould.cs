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
            Action wrongPlay = () => game.Play(new Tile(BottomLeft, O));

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid first player", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerXToPlayTwiceInARow()
        {
            game.Play(new Tile(BottomLeft, X));
            
            Action wrongPlay = () => game.Play(new Tile(BottomMiddle,X));

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid next player", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerToPlayInLastPlayedPosition()
        {
            game.Play(new Tile(BottomLeft,X));

            Action wrongPlay = () => game.Play(new Tile(BottomLeft, O));

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid position", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerToPlayInAnyPlayedPosition()
        {
            game.Play(new Tile(BottomLeft, X));
            game.Play(new Tile(BottomMiddle, O));

            Action wrongPlay = () => game.Play(new Tile(BottomLeft, X));

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
            game.Play(new Tile(BottomMiddle, X));
            game.Play(new Tile(BottomLeft, O));
            game.Play(new Tile(CenterMiddle, X));
            game.Play(new Tile(CenterLeft, O));
            game.Play(new Tile(TopMiddle, X));

            var winner = game.Winner();

            Assert.Equal(X, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInMiddleRow()
        {
            game.Play(new Tile(BottomLeft, X));
            game.Play(new Tile(BottomMiddle, O));
            game.Play(new Tile(BottomRight, X));
            game.Play(new Tile(CenterMiddle, O));
            game.Play(new Tile(CenterRight, X));
            game.Play(new Tile(TopMiddle, O));

            var winner = game.Winner();

            Assert.Equal(O, winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInBottomRow()
        {
            game.Play(new Tile(BottomRight, X));
            game.Play(new Tile(BottomLeft, O));
            game.Play(new Tile(CenterRight, X));
            game.Play(new Tile(CenterLeft, O));
            game.Play(new Tile(TopRight, X));
            
            var winner = game.Winner();

            Assert.Equal(X, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInBottomRow()
        {
            game.Play(new Tile(BottomLeft, X));
            game.Play(new Tile(BottomRight, O));
            game.Play(new Tile(BottomMiddle, X));
            game.Play(new Tile(CenterRight, O));
            game.Play(new Tile(CenterMiddle, X));
            game.Play(new Tile(TopRight, O));

            var winner = game.Winner();

            Assert.Equal(O, winner);
        }
    }
}
