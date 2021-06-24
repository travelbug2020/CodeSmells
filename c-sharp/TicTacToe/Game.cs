using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using static TicTacToe.Player;

//board tile game
namespace TicTacToe
{
    
    // DIVERGANT CHANGE
    // Large Class
    public class Game
    {
        
        //PRIMITIVE OBBSESSION
        private Player _lastSymbol = EmptySpace;
        private Board _board = new Board();
        public Dictionary<char,Player> symbolToPlayer = new Dictionary<char, Player>()
        {
            {'X', X},
            {'O', O}
        };
        //LONG PARAMETER LIST
        //PRIMITIVE OBBSESSION
        //DATA CLUMP
        public void Play(char symbol, int x, int y)
        {
            var player = symbolToPlayer[symbol];
            EnsureValidMove(player, x, y);
            _lastSymbol = player;
            _board.AddTileAt(symbol, x, y);
        }

        private void EnsureValidMove(Player player, int x, int y)
        { 
            CheckIsInvalidFirstPlayer(player);
            CheckIsPlayerRepeated(player);
            _board.CheckIsPositionAlreadyPlayed(x, y);
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

        //Primitive OBBSESSION - CODE SMELL
        public char Winner()
        {
            for (int x = 0; x <= 2; x++)
            {
                if (_board.IsWinningRow(x))
                {
                    return _board.GetSymbolAtPosition(x, 0);
                }
            }

            return ' ';
        }

        




    }
}