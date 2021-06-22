using System;
using System.Security.Cryptography.X509Certificates;
//board tile game
namespace TicTacToe
{
    // DIVERGANT CHANGE
    // COMMENTS
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
        // FEATURE ENVY
        //Innappropiate intimicy
        //Message Chains
        public char Winner()
        {
            if (IsWinningRow(0))
            {
                return GetSymbolAtPosition(0, 0);
            }
            if (IsWinningRow(1))
            {
                return GetSymbolAtPosition(1, 0);
            }
            if (IsWinningRow(2))
            {
                return GetSymbolAtPosition(2, 0);
            }

            return ' ';
        }

        private bool IsWinningRow(int x)
        {
            return IsRowTaken(x) && HasRowGotSameSymbol(x);
        }

        private char GetSymbolAtPosition(int x, int y)
        {
            return _board.TileAt(x, y).Symbol;
        }

        private bool HasRowGotSameSymbol(int x)
        {
            return _board.TileAt(x, 0).Symbol ==
                   _board.TileAt(x, 1).Symbol &&
                   _board.TileAt(x, 2).Symbol ==
                   _board.TileAt(x, 1).Symbol;
        }

        private bool IsRowTaken(int x)
        {
            return _board.TileAt(x, 0).Symbol != ' ' &&
                   _board.TileAt(x, 1).Symbol != ' ' &&
                   _board.TileAt(x, 2).Symbol != ' ';
        }
    }
}