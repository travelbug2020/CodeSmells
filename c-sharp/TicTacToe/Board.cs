using System;
using System.Collections.Generic;
using System.Linq;
using static TicTacToe.Player;

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
                    _plays.Add(new Tile { X = i, Y = j, Player = EmptySpace });
                }
            }
        }
        //PRIMITIVE OBBSESSION
        public Tile CheckTileAt(int x, int y)
        {
            return _plays.Single(tile => tile.X == x && tile.Y == y);
        }
        //LONG PARAMETER LIST
        //PRIMITIVE OBBSESSION
        //DATA CLUMPS
        public void AddTileAt(Player player, int x, int y)
        {
            //Message Chain ??????
            _plays.Single(tile => tile.X == x && tile.Y == y).Player = player;
        }

        public bool IsRowTaken(int x)
        {
            return CheckTileAt(x, 0).Player != EmptySpace &&
                   CheckTileAt(x, 1).Player != EmptySpace &&
                   CheckTileAt(x, 2).Player != EmptySpace;
        }

        public bool HasRowGotSameSymbol(int x)
        {
            return CheckTileAt(x, 0).Player ==
                   CheckTileAt(x, 1).Player &&
                   CheckTileAt(x, 2).Player ==
                   CheckTileAt(x, 1).Player;
        }

        public bool IsWinningRow(int x)
        {
            return IsRowTaken(x) && HasRowGotSameSymbol(x);
        }
        public Player GetSymbolAtPosition(int x, int y)
        {
            return CheckTileAt(x, y).Player;
        }
        public void IsPositionAlreadyPlayed(int x, int y)
        {
            if (CheckTileAt(x, y).Player != EmptySpace)
            {
                throw new Exception("Invalid position");
            }
            
        }

    }
}