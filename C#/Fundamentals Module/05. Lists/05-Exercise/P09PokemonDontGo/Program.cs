namespace P09PokemonDontGo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            List<int> pokemonDistanceList = Console.ReadLine()
                      .Split()
                      .Select(int.Parse)
                      .ToList();

            int sum = 0;
                        int removedElement = 0;

            while (pokemonDistanceList.Count != 0)
            {
                int pokemonIndex = int.Parse(Console.ReadLine());

                int lastElement = pokemonDistanceList[pokemonDistanceList.Count - 1];
                int firstElement = pokemonDistanceList[0];

                if (pokemonIndex < 0)
                {
                    removedElement = firstElement;
                    pokemonDistanceList.RemoveAt(0);
                    pokemonDistanceList.Insert(0, lastElement);
                }
                else if (pokemonIndex > pokemonDistanceList.Count - 1)
                {
                    removedElement = lastElement;
                    pokemonDistanceList.RemoveAt(pokemonDistanceList.Count - 1);
                    pokemonDistanceList.Add(firstElement);
                }
                else
                {
                    removedElement = pokemonDistanceList[pokemonIndex];
                    pokemonDistanceList.RemoveAt(pokemonIndex);

                }

                sum += removedElement;

                UpdateDistance(pokemonDistanceList, removedElement);
            }

            Console.WriteLine(sum);
        }

        private static void UpdateDistance(List<int> pokemonDistanceList, int removedElement)
        {
            for (int i = 0; i < pokemonDistanceList.Count; i++)
            {
                int currentNumber = pokemonDistanceList[i];
                if (currentNumber <= removedElement)
                {
                    currentNumber += removedElement;
                    pokemonDistanceList[i] = currentNumber;
                }
                else
                {
                    currentNumber -= removedElement;
                    pokemonDistanceList[i] = currentNumber;

                }
            }
        }
    }
}