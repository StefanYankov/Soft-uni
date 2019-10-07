using System;
using System.Linq;

namespace _03._Easter_Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfShops = Console.ReadLine().Split().ToList();
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfCommands; i++)
            {
                var command = Console.ReadLine().Split().ToArray();

                if (command[0] == "Include")
                {
                    listOfShops.Add(command[1]);
                }
                else if (command[0] == "Visit")
                {
                    int numberOfShop = int.Parse(command[2]);
                    if (numberOfShop > listOfShops.Count())
                    {
                        continue;
                    }
                    //Visit first 2
                    if (command[1] == "first")
                    {
                        for (int j = 0; j < numberOfShop; j++)
                        {
                            int index = 0;
                            listOfShops.RemoveAt(index);
                        }
                    }
                    else if (command[1] == "last")
                    {
                        int minNumber = listOfShops.Count;
                        for (int j = listOfShops.Count-1; j > ((minNumber - numberOfShop) -1 ); j--)
                        {
                            listOfShops.RemoveAt(j);
                        }

                    }

                }
                else if (command[0] == "Prefer")
                {
                    int index1 = int.Parse(command[1]);
                    int index2 = int.Parse(command[2]);
                    if (index1 < listOfShops.Count() && index2 < listOfShops.Count())
                    {
                        //Prefer 3 1
                        string temp = listOfShops[index2];
                        listOfShops[index2] = listOfShops[index1];
                        listOfShops[index1] = temp;

                    }

                }
                else if (command[0] == "Place")
                {
                    int index = int.Parse(command[2]);
                    if ((index + 1 ) < listOfShops.Count())
                    {
                        listOfShops.Insert((index + 1), command[1]);
                    }

                }
            }
            Console.WriteLine("Shops left:");
            foreach (var item in listOfShops)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
