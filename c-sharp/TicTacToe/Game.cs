using System;
using static TicTacToe.Player;

namespace TicTacToe
{
    public class Game
    {
        private Player _lastSymbol = EmptySpace;
        private readonly Board _board = new Board();
        private Position _position;

        public void Play(Tile tile)
        {
            EnsureValidMove(tile);
            _position = tile.Position;
            _lastSymbol = tile.Player;
            _board.AddTileAt(tile);
        }

        private void EnsureValidMove(Tile tile)
        { 
            CheckIsInvalidFirstPlayer(tile);
            CheckIsPlayerRepeated(tile);
            _board.IsPositionAlreadyPlayed(tile);
        }

        private void CheckIsInvalidFirstPlayer(Tile tile)
        {
            if (IsInvalidFirstPlayer(tile.Player))
            {
                throw new Exception("Invalid first player");
            }
        }
        private void CheckIsPlayerRepeated(Tile tile)
        {
            if (IsPlayerRepeated(tile.Player))
            {
                throw new Exception("Invalid next player");
            }
        }

        private bool IsInvalidFirstPlayer(Player player)
        {
            return IsFirstMove() && IsPlayerO(player);
        }

        private bool IsPlayerRepeated(Player player)
        {
            return player == _lastSymbol;
        }

        private static bool IsPlayerO(Player player)
        {
            return player == O;
        }

        private bool IsFirstMove()
        {
            return _lastSymbol == EmptySpace;
        }

        public Player Winner()
        {
            if (_board.IsWinningRow(_position))
            {
                var playerInPosition = _board.GetSymbolAtPosition(_position);
                return playerInPosition;
            }

            return EmptySpace;
        }
    }
}
