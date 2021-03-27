using System;

namespace P04Collector
{
    public class StartUp
    {
        public static void Main()
        {
            Spy spy = new Spy();
            string result = spy.CollectGettersAndSetters("Hacker");
            Console.WriteLine(result);
        }
    }
}
