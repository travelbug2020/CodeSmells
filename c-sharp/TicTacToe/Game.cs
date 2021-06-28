using System;
using static TicTacToe.Player;

namespace TicTacToe
{
    // Large Class
    public class Game
    {
        private Player _lastSymbol = EmptySpace;
        private Board _board = new Board();
        private Position position;

        public void Play(Tile tile)
        {
            EnsureValidMove(tile);
            _lastSymbol = tile.Player;
            _board.AddTileAt(tile);
        }

        public void Play(char symbol, int x, int y)
        {
            Conversions conversion = new Conversions();
            position = conversion.coordsToPosition[$"{x},{y}"];
            var player = conversion.symbolToPlayer[symbol];
            var tile = new Tile(position, player);
            EnsureValidMove(tile); 
            _lastSymbol = player;
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

        public Player Winner_()
        {
            if (_board.IsWinningRow(position))
            {
                var playerInPosition = _board.GetSymbolAtPosition(position);
                return playerInPosition;
            }

            return EmptySpace;
        }
        public char Winner()
        {
            var winner = Winner_();
            return char.Parse(winner.ToString());
        }

    }
}
