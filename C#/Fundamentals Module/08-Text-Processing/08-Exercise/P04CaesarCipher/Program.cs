namespace P04CaesarCipher
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            StringBuilder sb = new StringBuilder();
            string normalText = Console.ReadLine();

            for (int i = 0; i < normalText.Length; i++)
            {
                int currentChar = (int)normalText[i] + 3;
                sb.Append((char)currentChar);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
