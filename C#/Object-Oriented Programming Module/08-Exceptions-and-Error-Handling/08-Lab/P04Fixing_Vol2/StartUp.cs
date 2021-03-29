using System;

namespace P04Fixing_Vol2
{
    public class StartUp
    {
        public static void Main()
        {
            int num1, num2;
            byte result;

            num1 = 30;
            num2 = 60;

            try
            {
                result = Convert.ToByte(num1 * num2);
                Console.WriteLine("{0} x {1} = {2}", num1, num2, result);
                Console.ReadLine();
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }

        }
    }
}
