using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gem_Hunters
{
    public class Player
    {
        public string Name { get; set; }    // Name property of type string 
        public Position Position { get; set; } //Position property of type Position (a custum class defined in "Position Class.cs")
        public int GemCount { get; set; }   // Gemcount property of type int

        // Constructor
        public Player(string name, Position position)
        {
            Name = name;
            Position = position;
            GemCount = 0;       // initializes the gemcount property to 0
        }

        public void Move(char direction)
        {
            switch (direction)
            {
                case 'L': Position.Y = Math.Max(Position.Y - 1, 0); break;
                case 'R': Position.Y = Math.Min(Position.Y + 1, 5); break;
                case 'U': Position.X = Math.Max(Position.X - 1, 0); break;
                case 'D': Position.X = Math.Min(Position.X + 1, 5); break;
            }
        }
    }
}
