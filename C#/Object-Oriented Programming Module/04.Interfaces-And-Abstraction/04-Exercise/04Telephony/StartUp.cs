using System;

using Telephony;

namespace _04Telephony
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine()
                .Split();
            string[] sites = Console.ReadLine()
                .Split();

            Smartphone smartphone = new Smartphone();

            foreach (string phone in phoneNumbers)
            {
                Console.WriteLine(smartphone.Call(phone));
            }

            foreach (string address in sites)
            {
                Console.WriteLine(smartphone.Browse(address));
            }
        }
    }
}
