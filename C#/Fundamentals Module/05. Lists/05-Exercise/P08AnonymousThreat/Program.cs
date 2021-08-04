namespace P08AnonymousThreat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            // Ivo Johny Tony Bony Mony
            List<string> names = Console.ReadLine().Split(" ").ToList();
            string commands = string.Empty;

            while (!(commands = Console.ReadLine()).Equals("3:1"))
            {
                string command = commands.Split(" ")[0];
                int index = int.Parse(commands.Split(" ")[1]);

                if (command.Equals("merge"))
                {
                    int startIndex = index;
                    startIndex = Math.Max(startIndex, 0);
                    startIndex = Math.Min(startIndex, names.Count - 1);

                    int endIndex = int.Parse(commands.Split(" ")[2]);
                    endIndex = Math.Max(0, endIndex);
                    endIndex = Math.Min(names.Count - 1, endIndex);

                    string concat = string.Empty;

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        concat += names[i];
                    }

                    names.RemoveRange(startIndex, endIndex - startIndex + 1);
                    names.Insert(startIndex, concat);
                }
                else if (command.Equals("divide"))
                {
                    int indexToDivide = index;
                    indexToDivide = Math.Max(0, indexToDivide);
                    indexToDivide = Math.Min(indexToDivide, names.Count - 1);
                    int partitions = int.Parse(commands.Split(" ")[2]);

                    string stringToDivide = names[indexToDivide];
                    int LengthOfSmallPieces = stringToDivide.Length / partitions;
                    List<string> dividedList = new List<string>();

                    int startIndex = 0;
                    for (int i = 0; i < partitions; i++)
                    {
                        if (i == partitions - 1)
                        {
                            string pieceToAdd = stringToDivide.Substring(startIndex, stringToDivide.Length - startIndex);
                            dividedList.Add(pieceToAdd);
                        }
                        else
                        {
                            string pieceToAdd = stringToDivide.Substring(startIndex, LengthOfSmallPieces);
                            dividedList.Add(pieceToAdd);
                            startIndex += LengthOfSmallPieces;
                        }
                    }

                    names.RemoveAt(indexToDivide);
                    names.InsertRange(indexToDivide, dividedList);
                }
            }

            Console.WriteLine(String.Join(" ", names));
        }
    }
}
