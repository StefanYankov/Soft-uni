using System;
using System.Linq;

namespace _8._Condense_Arr_to_Num
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (nums.Length > 1)
            {
                int[] condensedArr = new int[nums.Length - 1];
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    condensedArr[i] = nums[i] + nums[i + 1];
                }
                nums = condensedArr;

            }
            Console.WriteLine(nums[0]);
        }
    }
}
