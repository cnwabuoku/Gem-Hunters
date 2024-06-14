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
            Player1 = new Player("P1", new Position(0, 0));     //initializes starting position of P1
            Player2 = new Player("P2", new Position(5, 5));     //initializes starting position of P2
            Board = new Board(Player1, Player2);
            CurrentTurn = Player1;
            TotalTurns = 0;
        }

        public void Start()
        {
            while (!IsGameOver())
            {
                Board.Display();
                Console.WriteLine($"\n{CurrentTurn.Name}'s turn. Gems collected: {CurrentTurn.GemCount}");
                Console.Write("\nEnter your move (U, D, L, R): ");
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

                TotalTurns++;       //Increments TotalTurns after each turn
            }

            AnnounceWinner();       //Calls AnnounceWinner method when the game ends.
        }

        public void SwitchTurn()
        {
            CurrentTurn = CurrentTurn == Player1 ? Player2 : Player1;       //Switches the current turn to the other player.
        }

        public bool IsGameOver()
        {
            return TotalTurns >= 30;        //Returns true if the total number of turns is 30 or more, indicating the game is over.
        }

        public void AnnounceWinner()
        {
            Console.WriteLine("Game over!");
            Board.Display();
            Console.WriteLine($"\n{Player1.Name} collected {Player1.GemCount} gems.");
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
                Console.WriteLine("\nIt's a tie!");
            }
        }
    }
}
