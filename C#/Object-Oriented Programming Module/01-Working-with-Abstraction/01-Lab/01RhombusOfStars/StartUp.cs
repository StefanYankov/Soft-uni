using System;
using System.Text;

namespace _01RhombusofStars
{
   public class Program
    {
     public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var rhombusDrawer = new RhombusDrawer();
            var printing = rhombusDrawer.Draw(n);

            Console.WriteLine(printing);
        }
    }
}
