using System;
using System.Linq;

namespace P02ShootForTheWin
{
    public class StartUp
    {
        public static void Main()
        {
            int[] targets = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string shots;
            int shotTargets = 0;


            while (!((shots = Console.ReadLine()).Equals("End")))
            {
                int index = int.Parse(shots);
                if (index < 0 || index >= targets.Length || targets[index] == -1)
                {
                    continue;
                }
                int tempValue = targets[index];
                targets[index] = -1;
                shotTargets++;

                for (int i = 0; i < targets.Length; i++)
                {
                    if(targets[i] == -1)
                    {
                        continue;
                    }

                    if (targets[i] > tempValue)
                    {
                        targets[i] -= tempValue;
                    }
                    else
                    {
                        targets[i] += tempValue;
                    }
                }
            }
            Console.WriteLine($"Shot targets: {shotTargets} -> " + String.Join(' ', targets));
        }
    }
}
