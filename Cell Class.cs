using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gem_Hunters
{
    public class Cell
    {
        public string Occupant { get; set; }

        public Cell()
        {
            Occupant = "-";         //Initializes the Occupant property to the string "-", indicating that the cell is empty or unoccupied.
        }
    }
}
