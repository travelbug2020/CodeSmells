using System;
using Xunit;
using TicTacToe;
using static TicTacToe.Player;
using static TicTacToe.Position;

namespace TicTacToeTests
{
    public class GameShould
    {
        private readonly Game _game;

        public GameShould()
        {
           _game = new Game();
        }

        [Fact]
        public void NotAllowPlayerOToPlayFirst()
        {
            void WrongPlay() => _game.Play(new Tile(BottomLeft, O));

            var exception = Assert.Throws<Exception>(WrongPlay);
            Assert.Equal("Invalid first player", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerXToPlayTwiceInARow()
        {
            _game.Play(new Tile(BottomLeft, X));

            void WrongPlay() => _game.Play(new Tile(BottomMiddle, X));

            var exception = Assert.Throws<Exception>(WrongPlay);
            Assert.Equal("Invalid next player", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerToPlayInLastPlayedPosition()
        {
            _game.Play(new Tile(BottomLeft,X));

            void WrongPlay() => _game.Play(new Tile(BottomLeft, O));

            var exception = Assert.Throws<Exception>(WrongPlay);
            Assert.Equal("Invalid position", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerToPlayInAnyPlayedPosition()
        {
            _game.Play(new Tile(BottomLeft, X));
            _game.Play(new Tile(BottomMiddle, O));

            void WrongPlay() => _game.Play(new Tile(BottomLeft, X));

            var exception = Assert.Throws<Exception>(WrongPlay);
            Assert.Equal("Invalid position", exception.Message);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInTopRow()
        {
            _game.Play(new Tile(BottomLeft, X));
            _game.Play(new Tile(BottomMiddle, O));
            _game.Play(new Tile(CenterLeft, X));
            _game.Play(new Tile(CenterMiddle, O));
            _game.Play(new Tile(TopLeft, X));

            var winner = _game.Winner();

            Assert.Equal(X, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInTopRow()
        {
            _game.Play(new Tile(TopRight, X));
            _game.Play(new Tile(BottomLeft, O));
            _game.Play(new Tile(BottomMiddle, X));
            _game.Play(new Tile(CenterLeft, O));
            _game.Play(new Tile(CenterMiddle, X));
            _game.Play(new Tile(TopLeft, O));

            var winner = _game.Winner();

            Assert.Equal(O, winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInMiddleRow()
        {
            _game.Play(new Tile(BottomMiddle, X));
            _game.Play(new Tile(BottomLeft, O));
            _game.Play(new Tile(CenterMiddle, X));
            _game.Play(new Tile(CenterLeft, O));
            _game.Play(new Tile(TopMiddle, X));

            var winner = _game.Winner();

            Assert.Equal(X, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInMiddleRow()
        {
            _game.Play(new Tile(BottomLeft, X));
            _game.Play(new Tile(BottomMiddle, O));
            _game.Play(new Tile(BottomRight, X));
            _game.Play(new Tile(CenterMiddle, O));
            _game.Play(new Tile(CenterRight, X));
            _game.Play(new Tile(TopMiddle, O));

            var winner = _game.Winner();

            Assert.Equal(O, winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInBottomRow()
        {
            _game.Play(new Tile(BottomRight, X));
            _game.Play(new Tile(BottomLeft, O));
            _game.Play(new Tile(CenterRight, X));
            _game.Play(new Tile(CenterLeft, O));
            _game.Play(new Tile(TopRight, X));
            
            var winner = _game.Winner();

            Assert.Equal(X, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInBottomRow()
        {
            _game.Play(new Tile(BottomLeft, X));
            _game.Play(new Tile(BottomRight, O));
            _game.Play(new Tile(BottomMiddle, X));
            _game.Play(new Tile(CenterRight, O));
            _game.Play(new Tile(CenterMiddle, X));
            _game.Play(new Tile(TopRight, O));

            var winner = _game.Winner();

            Assert.Equal(O, winner);
        }
    }
}
