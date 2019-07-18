using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.SetsOfElements
{
    class SetsOfElementsProgram
    {
        static void Main()
        {
            int[] setsLength = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int nSetLenght = setsLength[0];
            int mSetLenght = setsLength[1];

            HashSet<int> nSet = new HashSet<int>();
            HashSet<int> mSet = new HashSet<int>();

            for (int i = 0; i < nSetLenght; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());
                nSet.Add(inputNumber);
            }

            for (int i = 0; i < mSetLenght; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());
                mSet.Add(inputNumber);
            }

            foreach (var number in nSet)
            {
                if (mSet.Contains(number))
                {
                    Console.Write(number + " ");
                }
            }

        }
    }
}
