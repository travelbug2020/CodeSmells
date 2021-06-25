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
        

        //LONG PARAMETER LIST
        //PRIMITIVE OBBSESSION
        //DATA CLUMP ss
        public void Play(char symbol, int x, int y)
        {
            Conversions conversion = new Conversions();
            var position = conversion.coordsToPosition[$"{x},{y}"];
            var player = conversion.symbolToPlayer[symbol];
            EnsureValidMove(player, x, y);
            _lastSymbol = player;
            _board.AddTileAt(player, x, y);
        }

        private void EnsureValidMove(Player player, int x, int y)
        { 
            CheckIsInvalidFirstPlayer(player);
            CheckIsPlayerRepeated(player);
            _board.IsPositionAlreadyPlayed(x, y);
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
            for (int x = 0; x <= 2; x++)
            {
                if (_board.IsWinningRow(x))
                {
                    var playerInPosition = _board.GetSymbolAtPosition(x, 0).ToString();
                    return char.Parse(playerInPosition);
                }
            }

            return ' ';
        }

        




    }
}