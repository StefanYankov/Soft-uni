namespace P03MaximalSum
{
    using System;
    using System.Linq;
    public class MaximalSumProgram
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[dimensions[0], dimensions[1]];
            long maxSum = long.MinValue;
            int[,] maxSumMatrix = new int[3, 3];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    var tempMatrix = new int[3, 3];

                    for (int tempr = 0; tempr < tempMatrix.GetLength(0); tempr++)
                    {
                        for (int tempc = 0; tempc < tempMatrix.GetLength(1); tempc++)
                        {
                            tempMatrix[tempr, tempc] = matrix[i + tempr, j + tempc];
                        }
                    }

                    long currentSum = 0;


                    foreach (var item in tempMatrix)
                    {
                        currentSum += item;
                    }

                    if (currentSum > maxSum)
                    {

                        maxSum = currentSum;
                        maxSumMatrix = tempMatrix;

                    }

                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int i = 0; i < maxSumMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < maxSumMatrix.GetLength(1); j++)
                {
                    Console.Write(maxSumMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
