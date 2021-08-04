namespace P02ChangeList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<int> integerList = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string commands;
            while (!(commands = Console.ReadLine()).Equals("end"))
            {
                string command = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
                int element = int.Parse(commands.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);

                if (command.Equals("Delete"))
                {
                    integerList.RemoveAll(x => x == element);
                }
                else
                {
                    int position = int.Parse(commands.Split(" ", StringSplitOptions.RemoveEmptyEntries)[2]);
                    integerList.Insert(position, element);
                }
            }

            Console.WriteLine(String.Join(' ', integerList));
        }
    }
}
