using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class ParkingLotProgram
    {
        static void Main()
        {
            HashSet<string> carNumbers = new HashSet<string>();
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (input[0] != "END")
            {
                string command = input[0];
                string carNumber = input[1];

                if (command == "IN,")
                {
                    carNumbers.Add(carNumber);
                }
                else
                {
                    if (carNumbers.Contains(carNumber))
                    {
                        carNumbers.Remove(carNumber);
                    }
                }

                input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            if (carNumbers.Count > 0)
            {
                foreach (var numbers in carNumbers)
                {
                    Console.WriteLine(numbers);
                }

            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
           
        }
    }
}
