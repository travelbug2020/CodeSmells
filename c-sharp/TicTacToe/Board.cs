using System;
using System.Collections.Generic;
using System.Linq;
using static TicTacToe.Player;
using static TicTacToe.Position;

namespace TicTacToe
{
    
    public class Board
    {
        public List<Tile> _plays = new List<Tile>();

        public Board()
        {
            _plays.Add(new Tile(BottomLeft,EmptySpace));
            _plays.Add(new Tile(BottomMiddle,EmptySpace));
            _plays.Add(new Tile(BottomRight,EmptySpace));
            _plays.Add(new Tile(CenterLeft,EmptySpace));
            _plays.Add(new Tile(CenterMiddle,EmptySpace));
            _plays.Add(new Tile(CenterRight,EmptySpace));
            _plays.Add(new Tile(TopLeft,EmptySpace));
            _plays.Add(new Tile(TopMiddle,EmptySpace));
            _plays.Add(new Tile(TopRight,EmptySpace));
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