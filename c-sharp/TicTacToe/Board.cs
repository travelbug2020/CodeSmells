using System;
using System.Collections.Generic;
using System.Linq;
using static TicTacToe.Player;

namespace TicTacToe
{
    
    public class Board
    {
        public List<Tile> _plays = new List<Tile>();

        public Board()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    _plays.Add(Tile.From(' ',x,y));
                }
            }
        }
        public Tile CheckTileAt(Position position)
        {
            return _plays.Single(tile => tile.Position == position);
        }
        
        public void AddTileAt(Tile tile)
        {
            _plays.Remove(new Tile(tile.Position,EmptySpace));
            _plays.Add(tile);
            
        }

        public bool IsRowTaken(Position position)
        {
            return CheckTileAt(position).Player != EmptySpace &&
                   CheckTileAt(position).Player != EmptySpace &&
                   CheckTileAt(position).Player != EmptySpace;
        }

        public bool HasRowGotSameSymbol(Position position)
        {
            return CheckTileAt(position).Player ==
                   CheckTileAt(position).Player &&
                   CheckTileAt(position).Player ==
                   CheckTileAt(position).Player;
        }

        public bool IsWinningRow(Position position)
        {
            return IsRowTaken(position) && HasRowGotSameSymbol(position);
        }
        public Player GetSymbolAtPosition(Position position)
        {
            return CheckTileAt(position).Player;
        }
        public void IsPositionAlreadyPlayed(Tile tile)
        {
            if (CheckTileAt(tile.Position).Player != EmptySpace)
            {
                throw new Exception("Invalid position");
            }
            
        }

    }
}