using System;
using System.Security.Cryptography.X509Certificates;
//board tile game
namespace TicTacToe
{
    // DIVERGANT CHANGE
    // COMMENTS
    // Large Class
    public class Game
    {
        //PRIMITIVE OBBSESSION
        private char _lastSymbol = ' ';
        private Board _board = new Board();

        //LONG PARAMETER LIST
        //PRIMITIVE OBBSESSION
        //DATA CLUMP
        public void Play(char symbol, int x, int y)
        {
            EnsureValidMove(symbol, x, y);
            _lastSymbol = symbol;
            _board.AddTileAt(symbol, x, y);
        }

        private void EnsureValidMove(char symbol, int x, int y)
        {
            //Switch Statement
            if (IsInvalidFirstPlayer(symbol))
            {
                throw new Exception("Invalid first player");
            }

            if (IsPlayerRepeated(symbol))
            {
                throw new Exception("Invalid next player");
            }

            if (IsPositionAlreadyPlayed(x, y))
            {
                throw new Exception("Invalid position");
            }
        }

        private bool IsInvalidFirstPlayer(char symbol)
        {
            return IsFirstMove() && IsPlayerO(symbol);
        }

        private bool IsPositionAlreadyPlayed(int x, int y)
        {
            //Message Chain
            return _board.TileAt(x, y).Symbol != ' ';
        }

        private bool IsPlayerRepeated(char symbol)
        {
            return symbol == _lastSymbol;
        }

        private static bool IsPlayerO(char symbol)
        {
            return symbol == 'O';
        }

        private bool IsFirstMove()
        {
            return _lastSymbol == ' ';
        }

        //Primitive OBBSESSION - CODE SMELL
        //Message Chains
        
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