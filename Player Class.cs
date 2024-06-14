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

        /**public void Move(char direction)
        {
            switch (direction)
            {
                case 'U': // Move up
                    Position.Y = Math.Max(Position.Y - 1, 0);
                    break;
                case 'D': // Move down
                    Position.Y = Math.Min(Position.Y + 1, 5);
                    break;
                case 'L': // Move left
                    Position.X = Math.Max(Position.X - 1, 0);
                    break;
                case 'R': // Move right
                    Position.X = Math.Min(Position.X + 1, 5);
                    break;
                default:
                    Console.WriteLine("Invalid move direction. Use 'U', 'D', 'L', or 'R'.");
                    break;
            }
        }**/

        /**public void Move(char direction)
        {
            switch (direction)
            {
                case 'U': // Move left
                    Position.X = Math.Max(Position.X - 1, 0);
                    break;
                case 'D': // Move right
                    Position.X = Math.Min(Position.X + 1, 5);
                    break;
                case 'L': // Move up
                    Position.Y = Math.Max(Position.Y - 1, 0);
                    break;
                case 'R': // Move down
                    Position.Y = Math.Min(Position.Y + 1, 5);
                    break;
                default:
                    Console.WriteLine("Invalid move direction. Use 'U', 'D', 'L', or 'R'.");
                    break;
            }
        }**/

        public void Move(char direction)
        {
            switch (direction)
            {
                // case 'U': Position.Y -= 1; break;
                // case 'D': Position.Y += 1; break;
                // case 'L': Position.Y -= 1; break;
                // case 'R': Position.Y += 1; break;

                case 'L': Position.Y = Math.Max(Position.Y - 1, 0); break;
                case 'R': Position.Y = Math.Min(Position.Y + 1, 5); break;
                case 'U': Position.X = Math.Max(Position.X - 1, 0); break;
                case 'D': Position.X = Math.Min(Position.X + 1, 5); break;
            }
        }
    }
}
