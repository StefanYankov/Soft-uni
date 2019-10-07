using System;

namespace P05Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string login = Console.ReadLine();
            string result = "";
            int counter = 1;

            for (int i = login.Length - 1; i >= 0; i--)
            {
                result += login[i];
            }

            string password = Console.ReadLine();

            while (password != result)
            {
                if (counter == 4)
                {
                    Console.WriteLine($"User {login} blocked!");
                    return;
                }
                Console.WriteLine("Incorrect password. Try again.");
                password = Console.ReadLine();
                counter += 1;
            }

            Console.WriteLine($"User {login} logged in.");

            
        }
    }
}
