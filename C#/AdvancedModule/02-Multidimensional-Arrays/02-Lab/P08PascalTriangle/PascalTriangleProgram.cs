namespace P07PascalTriangle
{
    using System;
    using System.Text;
    public class PascalTriangleProgram
    {
        public static void Main()
        {
            int height = int.Parse(Console.ReadLine());
            long[][] pascalTriangle = new long[height][];

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
            Console.WriteLine(PrintPascalTriangle(pascalTriangle));
        }

        private static string PrintPascalTriangle(long[][] pascalTriangle)
        {
            StringBuilder sb = new StringBuilder();
            foreach (long[] value in pascalTriangle)
            {
                sb.AppendLine(String.Join(" ", value));
            }

            return sb.ToString();
        }
    }
}
