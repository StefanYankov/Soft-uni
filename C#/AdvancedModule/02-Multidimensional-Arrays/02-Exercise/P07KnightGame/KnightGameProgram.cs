namespace P07KnightGame
{
    using System;
    public class KnightGameProgram
    {
        public static void Main()
        {
            int boardSize = int.Parse(Console.ReadLine());
            char[,] board = new char[boardSize, boardSize];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = input[j];
                }
            }

            int knightsToRemove = 0;

            while (true)
            {
                int maxAttacks = 0;
                int knightRow = 0;
                int knightCol = 0;
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        int currentAttacks = 0;
                        if (!board[row, col].Equals('K'))
                        {
                            continue;
                        }

                        if (IsOnBoard(board, row - 2, col - 1))
                        {
                            if (board[row - 2, col - 1] == 'K')
                            {
                                currentAttacks++;
                            }
                        }
                        if (IsOnBoard(board, row - 2, col + 1))
                        {
                            if (board[row - 2, col + 1] == 'K')
                            {
                                currentAttacks++;
                            }
                        }
                        if (IsOnBoard(board, row - 1, col + 2))
                        {
                            if (board[row - 1, col + 2] == 'K')
                            {
                                currentAttacks++;
                            }
                        }
                        if (IsOnBoard(board, row - 1, col - 2))
                        {
                            if (board[row - 1, col - 2] == 'K')
                            {
                                currentAttacks++;
                            }
                        }
                        if (IsOnBoard(board, row + 1, col - 2))
                        {
                            if (board[row + 1, col - 2] == 'K')
                            {
                                currentAttacks++;
                            }
                        }
                        if (IsOnBoard(board, row + 1, col + 2))
                        {
                            if (board[row + 1, col + 2] == 'K')
                            {
                                currentAttacks++;
                            }
                        }
                        if (IsOnBoard(board, row + 2, col - 1))
                        {
                            if (board[row + 2, col - 1] == 'K')
                            {
                                currentAttacks++;
                            }
                        }
                        if (IsOnBoard(board, row + 2, col + 1))
                        {
                            if (board[row + 2, col + 1] == 'K')
                            {
                                currentAttacks++;
                            }
                        }

                        if (currentAttacks > maxAttacks)
                        {
                            maxAttacks = currentAttacks;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }

                if (maxAttacks == 0)
                {
                    Console.WriteLine(knightsToRemove);
                    break;
                }
                else
                {
                    board[knightRow, knightCol] = '0';
                    knightsToRemove++;
                }
            }
        }

        private static bool IsOnBoard(char[,] board, int row, int col)
        {
            if (row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
