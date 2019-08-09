using System;


namespace _05.DateModifier
{
    public class StartUp
    {
        static void Main()
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateModifier date = new DateModifier();

            Console.WriteLine(date.GetDateDifference(firstDate, secondDate));
        }
    }
}
