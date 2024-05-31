using System;

namespace GemHunters{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Player
    {
        public string Name { get; set; }
        public Position Position { get; set; }
        public int GemCount { get; set; }

        public Player(string name, Position position)
        {
            Name = name;
            Position = position;
            GemCount = 0;
        }

        public void Move(char direction)
        {
            switch (direction)
            {
                case 'U': Position.Y = Math.Max(Position.Y - 1, 0); break;
                case 'D': Position.Y = Math.Min(Position.Y + 1, 5); break;
                case 'L': Position.X = Math.Max(Position.X - 1, 0); break;
                case 'R': Position.X = Math.Min(Position.X + 1, 5); break;
            }
        }
    }


}

