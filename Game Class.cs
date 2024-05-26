using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gem_Hunters
{
    public class Game
    {
        public Board Board { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Player CurrentTurn { get; set; }
        public int TotalTurns { get; set; }

        public Game()
        {
            Player1 = new Player("P1", new Position(0, 0));
            Player2 = new Player("P2", new Position(5, 5));
            Board = new Board(Player1, Player2);
            CurrentTurn = Player1;
            TotalTurns = 0;
        }

        public void Start()
        {
            while (!IsGameOver())
            {
                Board.Display();
                Console.WriteLine($"{CurrentTurn.Name}'s turn. Gems collected: {CurrentTurn.GemCount}");
                Console.Write("Enter your move (U, D, L, R): ");
                char move = Char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (Board.IsValidMove(CurrentTurn, move))
                {
                    Board.Grid[CurrentTurn.Position.X, CurrentTurn.Position.Y].Occupant = "-";
                    CurrentTurn.Move(move);
                    Board.CollectGem(CurrentTurn);
                    Board.Grid[CurrentTurn.Position.X, CurrentTurn.Position.Y].Occupant = CurrentTurn.Name;
                    SwitchTurn();
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                }

                TotalTurns++;
            }

            AnnounceWinner();
        }

        public void SwitchTurn()
        {
            CurrentTurn = CurrentTurn == Player1 ? Player2 : Player1;
        }

        public bool IsGameOver()
        {
            return TotalTurns >= 30;
        }

        public void AnnounceWinner()
        {
            Console.WriteLine("Game over!");
            Board.Display();
            Console.WriteLine($"{Player1.Name} collected {Player1.GemCount} gems.");
            Console.WriteLine($"{Player2.Name} collected {Player2.GemCount} gems.");

            if (Player1.GemCount > Player2.GemCount)
            {
                Console.WriteLine($"{Player1.Name} wins!");
            }
            else if (Player2.GemCount > Player1.GemCount)
            {
                Console.WriteLine($"{Player2.Name} wins!");
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }
        }
    }
}
