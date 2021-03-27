using System;

namespace P03MissionPrivateImpossible
{
   public class StartUp
    {
        public static void Main()
        {
            Spy spy = new Spy();
            string result = spy.RevealPrivateMethods("Hacker");
            Console.WriteLine(result);
        }
    }
}
