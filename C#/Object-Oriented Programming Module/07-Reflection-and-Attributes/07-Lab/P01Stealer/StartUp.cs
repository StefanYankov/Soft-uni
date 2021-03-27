using System;

namespace P01Stealer
{
    public class StartUp
    {
        public static void Main()
        {
            Spy spy = new Spy();
            string result = spy.StealFieldInfo("Hacker", "username", "password");
            Console.WriteLine(result);

        }
    }
}
