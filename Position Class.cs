using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gem_Hunters
{
    public class Position
    {
        public int X { get; set; }  // property X
        public int Y { get; set; }  // property Y

        public Position(int x, int y)  // constructor with parameters x and y of type int
        {
            X = x;
            Y = y;
        }
    }
}


//The Position class is a simple representation of a point in a 2D space with two properties, X and Y, to hold the coordinates. 
//The constructor of the class initializes these properties when a new instance of the Position class is created.