using System.Collections.Generic;
using static TicTacToe.Player;
using static TicTacToe.Position;

namespace TicTacToe
{
    public class Conversions
    {
        public readonly Dictionary<char, Player> symbolToPlayer = new Dictionary<char, Player>()
        {
            {'X', X},
            {'O', O}
        };

        public Dictionary<string, Position> coordsToPosition = new Dictionary<string, Position>()
        {
            {"0,0",BottomLeft},
            {"0,1",CenterLeft},
            {"0,2",TopLeft},
            {"1,0",BottomMiddle},
            {"1,1",CenterMiddle},
            {"1,2",TopMiddle},
            {"2,0",BottomRight},
            {"2,1",CenterRight},
            {"2,2",TopRight}
        };
    }
}
