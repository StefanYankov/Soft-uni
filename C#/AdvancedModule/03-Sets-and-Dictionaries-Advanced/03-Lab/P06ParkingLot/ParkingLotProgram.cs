namespace P06ParkingLot
{
    using System;
    using System.Collections.Generic;
    public class ParkingLotProgram
    {
        public static void Main()
        {
            HashSet<string> parking = new HashSet<string>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];

                if (command.Equals("END"))
                {
                    break;
                }

                string licenseNumber = input[1];
                if (command.Equals("IN"))
                {
                    parking.Add(licenseNumber);
                }
                else if (command.Equals("OUT"))
                {
                    if (parking.Contains(licenseNumber))
                    {
                        parking.Remove(licenseNumber);
                    }
                }
            }

            if (parking.Count != 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine,parking));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
