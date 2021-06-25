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
        Conversions conversions = new Conversions();

        public Board()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    var position = conversions.coordsToPosition[$"{x},{y}"];
                    _plays.Add(new Tile { Position = position, Player = EmptySpace });
                }
            }
        }
        //PRIMITIVE OBBSESSION
        public Tile CheckTileAt(Position position)
        {
            return _plays.Single(tile => tile.Position == position);
        }
        //LONG PARAMETER LIST
        //PRIMITIVE OBBSESSION
        //DATA CLUMPS
        public void AddTileAt(Player player, Position position)
        {
            //Message Chain ??????
            _plays.Single(tile => tile.Position == position).Player = player;
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