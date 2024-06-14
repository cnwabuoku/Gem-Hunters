using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gem_Hunters
{
    public class Board
    {
        public Cell[,] Grid { get; set; }       // Defines a 2D array property 'Grid' of type 'Cell'

        public Board(Player player1, Player player2) //Constructor
        {
            Grid = new Cell[6, 6];              //Initalizes a 6x6 'Grid' of 'Cell' objects
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Grid[i, j] = new Cell();
                }
            }
            SetPlayers(player1, player2);
            SetGems(5); // Place 5 gems
            SetObstacles(5); // Place 5 obstacles
        }

        public void SetPlayers(Player player1, Player player2)
        {
            Grid[player1.Position.X, player1.Position.Y].Occupant = player1.Name; // sets player1 at its position on the board
            Grid[player2.Position.X, player2.Position.Y].Occupant = player2.Name;   //sets the position of player2 on the board
        }

        public void SetGems(int gemCount)                   //Places a specified number of gems (gemCount) randomly on the board.
        {
            Random rand = new Random();                     //Uses a Random object to generate random coordinates within the 6x6 grid.
            int placed = 0;
            while (placed < gemCount)
            {
                int x = rand.Next(6);   
                int y = rand.Next(6);
                if (Grid[x, y].Occupant == "-")             //Checks if the cell at the generated coordinates is unoccupied ("-"), then places a gem ("G") there.
                {
                    Grid[x, y].Occupant = "G";
                    placed++;
                }
            }
        }

        public void SetObstacles(int obstacleCount)
        {
            Random rand = new Random();
            int placed = 0;
            while (placed < obstacleCount)
            {
                int x = rand.Next(6);
                int y = rand.Next(6);
                if (Grid[x, y].Occupant == "-")
                {
                    Grid[x, y].Occupant = "O";
                    placed++;
                }
            }
        }

        public void Display()               // Display method to display the board and iterate over the 6x6 grid and print the occupant of each cell.
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write(Grid[i, j].Occupant + " ");
                }
                Console.WriteLine();
            }
        }

        public bool IsValidMove(Player player, char direction)
        {
            int newX = player.Position.X;
            int newY = player.Position.Y;

            switch (direction)
            {
                case 'L': newY--; break;
                case 'R': newY++; break;
                case 'U': newX--; break;
                case 'D': newX++; break;
            }

            if (newX < 0 || newX >= 6 || newY < 0 || newY >= 6)
                return false;

            if (Grid[newX, newY].Occupant == "O")
                return false;

            return true;
        }

        public void CollectGem(Player player)
        {
            if (Grid[player.Position.X, player.Position.Y].Occupant == "G")     //Allows a player to collect a gem if they are on a cell containing a gem ("G").
            {
                player.GemCount++;                                              //Increments the player's gem count.
                Grid[player.Position.X, player.Position.Y].Occupant = "-";      //Removes the gem from the cell by setting the occupant to "-".
            }
        }
    }
}
