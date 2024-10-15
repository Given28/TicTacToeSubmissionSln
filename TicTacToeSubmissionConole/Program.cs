using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new TicTacToe();
            game.Run();
        }
    }

    public class TicTacToe
    {
        // Array to represent the game board
        private char[] board = new char[9];
        // current player, starting with 'X'
        private char currentPlayer = 'X';

        public TicTacToe()
        {
            // Initialize the board with empty spaces
            for (int i = 0; i < board.Length; i++)
                board[i] = ' ';
        }

        public void Run()
        {
            // Display the current state of the board
            int moves = 0;

            while (true)
            {
                displayBoard();
                Console.WriteLine($"Player {currentPlayer}, enter your move (1-9):");

                int move;
                // Validate user input
                if (!int.TryParse(Console.ReadLine(), out move) || move < 1 || move > 9 || board[move - 1] != ' ')
                {
                    Console.WriteLine("Invalid move. Try again.");
                    continue; // Prompt for input again
                }

                // place the current player's mark on the board
                board[move - 1] = currentPlayer;
                moves++;

                if (CheckForWinner())
                {
                    displayBoard(); // Show final board state
                    Console.WriteLine($"Player {currentPlayer} wins!");
                    break; // exit the loop
                }
                // Check for a draw
                if (moves == 9)
                {
                    displayBoard();
                    Console.WriteLine("It's a draw!");
                    break; // Exit the loop
                }

                // Switch to the other player
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }
        }

        private void displayBoard()
        {
            Console.Clear();
            // Print the current state of the board
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
        }

        private bool CheckForWinner()
        {
            // Define winningCombinations
            int[][] winningCombinations = new int[][]
            {
                new int[] { 0, 1, 2 },
                new int[] { 3, 4, 5 },
                new int[] { 6, 7, 8 },
                new int[] { 0, 3, 6 },
                new int[] { 1, 4, 7 },
                new int[] { 2, 5, 8 },
                new int[] { 0, 4, 8 },
                new int[] { 2, 4, 6 }
            };
            // Check each winning combinations
            foreach (var combo in winningCombinations)
            {
                if (board[combo[0]] == currentPlayer &&
                    board[combo[1]] == currentPlayer &&
                    board[combo[2]] == currentPlayer)
                {
                    return true; // Current player has won
                }
            }

            return false; // No winner yet
        }
    }
}

