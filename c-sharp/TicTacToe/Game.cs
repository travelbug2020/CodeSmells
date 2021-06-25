using System;
using System.Collections.Generic;
using static TicTacToe.Player;

namespace TicTacToe
{
    // DIVERGANT CHANGE
    // Large Class
    public class Game
    {
        //PRIMITIVE OBBSESSION
        private Player _lastSymbol = EmptySpace;
        private Board _board = new Board();
        private Position position;
        //LONG PARAMETER LIST
        //PRIMITIVE OBBSESSION
        //DATA CLUMP ss
        public void Play(char symbol, int x, int y)
        {
            Conversions conversion = new Conversions();
            position = conversion.coordsToPosition[$"{x},{y}"];
            var player = conversion.symbolToPlayer[symbol];
            EnsureValidMove(player, position);
            _lastSymbol = player;
            _board.AddTileAt(player, position);
        }

        private void EnsureValidMove(Player player, Position position)
        { 
            CheckIsInvalidFirstPlayer(player);
            CheckIsPlayerRepeated(player);
            _board.IsPositionAlreadyPlayed(position);
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
