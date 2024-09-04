using System;

namespace Fifteen
{
    class Program
    {
        // Constants
        const int DIM_MIN = 3;
        const int DIM_MAX = 9;

        // Board and dimensions
        static int[,] board = new int[DIM_MAX, DIM_MAX];
        static int d;

        static void Main(string[] args)
        {
            // Greet user with instructions
            Greet();

            // Ensure proper usage
            if (args.Length != 1 || !int.TryParse(args[0], out d) || d < DIM_MIN || d > DIM_MAX)
            {
                Console.WriteLine("Usage: fifteen d\nBoard must be between {0} x {0} and {1} x {1}, inclusive.", DIM_MIN, DIM_MAX);
                return;
            }

            // Initialize the board
            Init();

            // Accept moves until the game is won
            while (true)
            {
                // Clear the screen
                Clear();

                // Draw the current state of the board
                Draw();

                // Check for win
                if (Won())
                {
                    Console.WriteLine("ftw!");
                    break;
                }

                // Prompt for move
                Console.Write("Tile to move: ");
                if (int.TryParse(Console.ReadLine(), out int tile) && Move(tile))
                {
                    // Move if possible
                    continue;
                }
                else
                {
                    Console.WriteLine("\nIllegal move.");
                    System.Threading.Thread.Sleep(500);
                }

                // Sleep thread for animation's sake
                System.Threading.Thread.Sleep(500);
            }
        }

        // Clears screen using ANSI escape sequences.
        static void Clear()
        {
            Console.Clear();
        }

        // Greets player.
        static void Greet()
        {
            Clear();
            Console.WriteLine("WELCOME TO THE GAME OF FIFTEEN");
            System.Threading.Thread.Sleep(2000);
        }

        // Initializes the game's board with tiles numbered 1 through d*d - 1
        static void Init()
        {
            int change;
            for (int i = 0; i < d; i++)
            {
                for (int j = 0; j < d; j++)
                {
                    if (i == d - 1 && j == d - 1)
                    {
                        board[i, j] = 95;
                    }
                    else
                    {
                        board[i, j] = (d * d - 1) - (i * d + j);
                    }
                }
            }
            change = board[d - 1, d - 2];
            board[d - 1, d - 2] = board[d - 1, d - 3];
            board[d - 1, d - 3] = change;
        }

        // Prints the board in its current state.
        static void Draw()
        {
            for (int i = 0; i < d; i++)
            {
                for (int j = 0; j < d; j++)
                {
                    if (board[i, j] == 95)
                    {
                        Console.Write(" _  ");
                    }
                    else
                    {
                        Console.Write("{0,2}  ", board[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }

        // If tile borders empty space, moves tile and returns true, else returns false.
        static bool Move(int tile)
        {
            int emptyRow = 0, emptyCol = 0;

            // Find the empty space
            for (int i = 0; i < d; i++)
            {
                for (int j = 0; j < d; j++)
                {
                    if (board[i, j] == 95)
                    {
                        emptyRow = i;
                        emptyCol = j;
                        break;
                    }
                }
            }

            // Check adjacent tiles
            if (emptyCol > 0 && board[emptyRow, emptyCol - 1] == tile) // Left
            {
                Swap(ref board[emptyRow, emptyCol], ref board[emptyRow, emptyCol - 1]);
                return true;
            }
            if (emptyCol < d - 1 && board[emptyRow, emptyCol + 1] == tile) // Right
            {
                Swap(ref board[emptyRow, emptyCol], ref board[emptyRow, emptyCol + 1]);
                return true;
            }
            if (emptyRow > 0 && board[emptyRow - 1, emptyCol] == tile) // Up
            {
                Swap(ref board[emptyRow, emptyCol], ref board[emptyRow - 1, emptyCol]);
                return true;
            }
            if (emptyRow < d - 1 && board[emptyRow + 1, emptyCol] == tile) // Down
            {
                Swap(ref board[emptyRow, emptyCol], ref board[emptyRow + 1, emptyCol]);
                return true;
            }

            return false;
        }

        // Returns true if game is won (i.e., board is in winning configuration), else false.
        static bool Won()
        {
            int temp = 1;
            for (int i = 0; i < d; i++)
            {
                for (int j = 0; j < d; j++)
                {
                    if (i == d - 1 && j == d - 1) return true;
                    if (board[i, j] != temp) return false;
                    temp++;
                }
            }
            return true;
        }

        // Swap two values
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
