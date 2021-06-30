﻿using System;
using System.Collections.Generic;
using System.Linq;
using static TicTacToe.Player;
using static TicTacToe.Position;

namespace TicTacToe
{
    
    public class Board
    {
        private readonly List<Tile> _tiles = new List<Tile>();
        public readonly List<Position[]> WinningPositions = new List<Position[]>
        {
            new[] {TopLeft, TopMiddle, TopRight},
            new[] {CenterLeft,CenterMiddle,CenterRight},
            new[] {BottomLeft,BottomMiddle,BottomRight},
            new[] {TopLeft,CenterLeft,BottomLeft},
            new[] {TopMiddle,CenterMiddle,BottomMiddle},
            new[] {TopRight,CenterRight,BottomRight},
            new[] {TopRight,CenterMiddle,BottomLeft},
            new[] {TopLeft,CenterMiddle,BottomRight}

        };

        public Board()
        {
            _tiles.Add(new Tile(BottomLeft,EmptySpace));
            _tiles.Add(new Tile(BottomMiddle,EmptySpace));
            _tiles.Add(new Tile(BottomRight,EmptySpace));
            _tiles.Add(new Tile(CenterLeft,EmptySpace));
            _tiles.Add(new Tile(CenterMiddle,EmptySpace));
            _tiles.Add(new Tile(CenterRight,EmptySpace));
            _tiles.Add(new Tile(TopLeft,EmptySpace));
            _tiles.Add(new Tile(TopMiddle,EmptySpace));
            _tiles.Add(new Tile(TopRight,EmptySpace));
        }
        public Tile CheckTileAt(Position position)
        {
            return _tiles.Single(tile => tile.Position == position);
        }
        
        public void AddTileAt(Tile tile)
        {
            _tiles.Remove(new Tile(tile.Position,EmptySpace));
            _tiles.Add(tile);
            
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

        public Player IsWinningPositionFound()
        {
            foreach (var position in WinningPositions)
            {
                if (CheckTileAt(position[0]).Player != EmptySpace &&
                    CheckTileAt(position[1]).Player != EmptySpace &&
                    CheckTileAt(position[2]).Player != EmptySpace &&
                    CheckTileAt(position[0]).Player ==
                    CheckTileAt(position[1]).Player &&
                    CheckTileAt(position[1]).Player ==
                    CheckTileAt(position[2]).Player)
                {
                    return CheckTileAt(position[0]).Player;
                }

            }
            
            return EmptySpace;
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