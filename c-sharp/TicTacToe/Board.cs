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
        readonly Conversions conversions = new Conversions();

        public Board()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    var position = conversions.coordsToPosition[$"{x},{y}"];
                    _plays.Add(new Tile ( position, EmptySpace ));
                    // [BottomRight, EmptySpace]
                }
            }
        }
        public Tile CheckTileAt(Position position)
        {
            return _plays.Single(tile => tile.Position == position);
        }
        //DataClump
        public void AddTileAt(Player player, Position position)
        {
            _plays.Remove(new Tile(position,EmptySpace));
            _plays.Add(new Tile(position,player));
            
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
        public void IsPositionAlreadyPlayed(Position position)
        {
            if (CheckTileAt(position).Player != EmptySpace)
            {
                throw new Exception("Invalid position");
            }
            
        }

    }
}