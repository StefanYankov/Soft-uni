using System;

namespace _03StudentSystem.IO
{
    public class ConsoleIOEngine : IIOEngine
    {
        public string Read()
        {
            return Console.ReadLine();
        }

        public void Write(string str)
        {
            Console.WriteLine(str);
        }
    }
}
