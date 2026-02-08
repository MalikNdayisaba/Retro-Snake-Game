using System;

namespace Retro_Snake_Game
{
    internal class Coord : IEquatable<Coord>
    {
        private int x;
        private int y;

        public int X { get { return x; } }
        public int Y { get { return y; } }

        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool Equals(Coord other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            return x == other.x && y == other.y;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Coord);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                // simple hash combining
                return (x * 397) ^ y;
            }
        }

        public void ApplyMovementDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    x--;
                    break;
                case Direction.Right:
                    x++;
                    break;
                case Direction.Up:
                    y--;
                    break;
                case Direction.Down:
                    y++;
                    break;
            }
        }

        public override string ToString()
        {
            return $"({x},{y})";
        }
    }
}