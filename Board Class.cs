using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gem_Hunters
{
    public class Board
    {
        public Cell[,] Grid { get; set; }

        public Board(Player player1, Player player2)
        {
            Grid = new Cell[6, 6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Grid[i, j] = new Cell();
                }
            }
            PlacePlayers(player1, player2);
            PlaceGems(5); // Place 5 gems
            PlaceObstacles(5); // Place 5 obstacles
        }

        public void PlacePlayers(Player player1, Player player2)
        {
            Grid[player1.Position.X, player1.Position.Y].Occupant = player1.Name;
            Grid[player2.Position.X, player2.Position.Y].Occupant = player2.Name;
        }

        public void PlaceGems(int gemCount)
        {
            Random rand = new Random();
            int placed = 0;
            while (placed < gemCount)
            {
                int x = rand.Next(6);
                int y = rand.Next(6);
                if (Grid[x, y].Occupant == "-")
                {
                    Grid[x, y].Occupant = "G";
                    placed++;
                }
            }
        }

        public void PlaceObstacles(int obstacleCount)
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

        public void Display()
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
                case 'U': newY--; break;
                case 'D': newY++; break;
                case 'L': newX--; break;
                case 'R': newX++; break;
            }

            if (newX < 0 || newX >= 6 || newY < 0 || newY >= 6)
                return false;

            if (Grid[newX, newY].Occupant == "O")
                return false;

            return true;
        }

        public void CollectGem(Player player)
        {
            if (Grid[player.Position.X, player.Position.Y].Occupant == "G")
            {
                player.GemCount++;
                Grid[player.Position.X, player.Position.Y].Occupant = "-";
            }
        }
    }
}
