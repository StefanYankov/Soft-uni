using System;

namespace P02HighQualityMistakes
{
    public class StartUp
    {
        public static void Main()
        {
            Spy spy = new Spy();
            string result = spy.AnalyzeAccessModifiers("Hacker");
            Console.WriteLine(result);
        }
    }
}
