using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    // SHOT GUN SURGERY
    public class Board
    {
        private List<Tile> _plays = new List<Tile>();

        public Board()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _plays.Add(new Tile { X = i, Y = j, Symbol = ' ' });
                }
            }
        }
        //PRIMITIVE OBBSESSION
        //DATA CLUMP
        public Tile TileAt(int x, int y)
        {
            return _plays.Single(tile => tile.X == x && tile.Y == y);
        }
        //LONG PARAMETER LIST
        //PRIMITIVE OBBSESSION
        //DATA CLUMPS
        public void AddTileAt(char symbol, int x, int y)
        {
            //Message Chain
            _plays.Single(tile => tile.X == x && tile.Y == y).Symbol = symbol;
        }

        public bool IsRowTaken(int x)
        {
            return TileAt(x, 0).Symbol != ' ' &&
                   TileAt(x, 1).Symbol != ' ' &&
                   TileAt(x, 2).Symbol != ' ';
        }

        public bool HasRowGotSameSymbol(int x)
        {
            return TileAt(x, 0).Symbol ==
                   TileAt(x, 1).Symbol &&
                   TileAt(x, 2).Symbol ==
                   TileAt(x, 1).Symbol;
        }

        public bool IsWinningRow(int x)
        {
            return IsRowTaken(x) && HasRowGotSameSymbol(x);
        }
        public char GetSymbolAtPosition(int x, int y)
        {
            return TileAt(x, y).Symbol;
        }
        public bool IsPositionAlreadyPlayed(int x, int y)
        {
            
            return TileAt(x, y).Symbol != ' ';
        }
    }
}