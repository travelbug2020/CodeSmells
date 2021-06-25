namespace TicTacToe
{
    public class Tile
    {
        public Tile(Position position, Player player)
        {
            this.Position = position;
            this.Player = player;
        }
        public Position Position;
        public Player Player { get; set; }

        protected bool Equals(Tile other)
        {
            return Position == other.Position && Player == other.Player;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Tile) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) Position * 397) ^ (int) Player;
            }
        }
    }
}