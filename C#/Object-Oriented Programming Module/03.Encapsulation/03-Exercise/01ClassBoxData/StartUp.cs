using System;

using _01ClassBoxData.Models;

namespace _01ClassBoxData
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double heigth = double.Parse(Console.ReadLine());

                Box box = new Box(length, width, heigth);

                Console.WriteLine(box.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
