﻿using System;
using System.Collections.Generic;
using System.Linq;
using static TicTacToe.Player;
using static TicTacToe.Position;

namespace TicTacToe
{
    
    public class Board
    {
        public Board()
        {
            _tiles.Add(new Tile(BottomLeft, EmptySpace));
            _tiles.Add(new Tile(BottomMiddle, EmptySpace));
            _tiles.Add(new Tile(BottomRight, EmptySpace));
            _tiles.Add(new Tile(CenterLeft, EmptySpace));
            _tiles.Add(new Tile(CenterMiddle, EmptySpace));
            _tiles.Add(new Tile(CenterRight, EmptySpace));
            _tiles.Add(new Tile(TopLeft, EmptySpace));
            _tiles.Add(new Tile(TopMiddle, EmptySpace));
            _tiles.Add(new Tile(TopRight, EmptySpace));
        }

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

        public Tile CheckTileAt(Position position)
        {
            return _tiles.Single(tile => tile.Position == position);
        }
        
        public void AddTileAt(Tile tile)
        {
            _tiles.Remove(new Tile(tile.Position,EmptySpace));
            _tiles.Add(tile);
            
        }

        public Player IsWinningPositionFound()
        {
            foreach (var position in WinningPositions.Where(position => CheckTileAt(position[0]).Player ==
                                                                        CheckTileAt(position[1]).Player &&
                                                                        CheckTileAt(position[1]).Player ==
                                                                        CheckTileAt(position[2]).Player && 
                                                                        CheckTileAt(position[2]).Player != EmptySpace))
            {
                return CheckTileAt(position[0]).Player;
            }

            return EmptySpace;
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