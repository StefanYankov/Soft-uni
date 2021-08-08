namespace P05MultiplyBigNumber
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            string number = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());

            if (multiplier == 0)
            {
                Console.WriteLine("0");
                return;
            }
            int remainder = 0;
            List<string> product = new List<string>();


            for (int i = number.Length - 1; i >= 0; i--)
            {
                int digit = number[i] - '0';

                remainder += digit * multiplier;

                if (remainder > 9)
                {
                    int remainderLastDigit = remainder % 10;
                    remainder /= 10;

                    product.Add(remainderLastDigit.ToString());
                }
                else
                {
                    product.Add(remainder.ToString());
                    remainder = 0;
                }
            }

            if (remainder > 0)
            {
                product.Add(remainder.ToString());
            }

            product.Reverse();
            Console.WriteLine(string.Join(string.Empty, product));
        }
    }
}
