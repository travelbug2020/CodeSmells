using System;
using System.Collections.Generic;
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
            CheckIsInvalidFirstPlayer(tile.Player);
            CheckIsPlayerRepeated(tile.Player);
            _board.IsPositionAlreadyPlayed(tile.Position);
        }

        private void CheckIsInvalidFirstPlayer(Player player)
        {
            if (IsInvalidFirstPlayer(player))
            {
                throw new Exception("Invalid first player");
            }
        }
        private void CheckIsPlayerRepeated(Player player)
        {
            if (IsPlayerRepeated(player))
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

        //Primitive OBBSESSION - CODE SMELL ?? Can't do anything about this cause of test

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
            if (_board.IsWinningRow(position))
            {
                var playerInPosition = _board.GetSymbolAtPosition(position).ToString();
                return char.Parse(playerInPosition);
            }

            return ' ';
        }

    }
}
