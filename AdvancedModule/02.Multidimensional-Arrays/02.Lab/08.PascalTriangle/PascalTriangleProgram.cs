using System;

namespace _08.PascalTriangle
{
    class PascalTriangleProgram
    {
        static void Main()
        {
            int rowCount = int.Parse(Console.ReadLine());

            long[][] pascalTriangle = new long[rowCount][];

            for (long i = 0; i < pascalTriangle.Length; i++)
            {
                pascalTriangle[i] = new long[i + 1];
                pascalTriangle[i][0] = 1;
                pascalTriangle[i][i] = 1;
            }

            for (long i = 0; i < pascalTriangle.Length; i++)
            {
                if (pascalTriangle[i].Length > 2)
                {
                    for (long j = 1; j < pascalTriangle[i].Length - 1; j++)
                    {
                        pascalTriangle[i][j] = pascalTriangle[i - 1][j] + pascalTriangle[i - 1][j - 1];

                    }
                }
            }

            foreach (var row in pascalTriangle)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }
    }
}
