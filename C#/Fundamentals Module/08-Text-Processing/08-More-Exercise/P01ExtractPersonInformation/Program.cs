namespace P01ExtractPersonInformation
{
    using System;
    public class Program
    {
        public static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());


            for (int i = 1; i <= numberOfLines; i++)
            {
                string input = Console.ReadLine();

                int nameStart = input.IndexOf('@') +1;
                int nameEnd = input.IndexOf('|');

                int ageStart = input.IndexOf('#') +1;
                int ageEnd = input.IndexOf('*');

                string name = input.Substring(nameStart, nameEnd - nameStart);
                string age = input.Substring(ageStart, ageEnd - ageStart);

                Console.WriteLine($"{name} is {age} years old.");
            }

        }
    }
}
