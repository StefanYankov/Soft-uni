using System;
using System.Collections.Generic;
using System.Linq;

namespace _05SetCover
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> universe = new List<int>() { 1, 2, 3, 4, 5};

            List<int[]> sets = new List<int[]>()
            {
                new int[] {89, 56, 7, 23, 1},
                new int[] {2, 3, 67},
                new int[] {4},
                new int[] {5},
                new int[] {98, 45, 67, 23},
                new int[] {7, 4, 2, 5}
            };

            Console.WriteLine(ChooseSets(sets, universe));
        }

        public static List<int[]> ChooseSets(List<int[]> sets, List<int> universe)
        {
            List<int[]> selectedSets = new List<int[]>();
            while (universe.Count > 0)
            {
                int[] current = sets.OrderByDescending(set => set.Count(universe.Contains)).First();

                selectedSets.Add(current);
                sets.Remove(current);

                foreach (int i in current)
                {
                    universe.Remove(i);
                }

                return selectedSets;

            }
        }

    }
}
