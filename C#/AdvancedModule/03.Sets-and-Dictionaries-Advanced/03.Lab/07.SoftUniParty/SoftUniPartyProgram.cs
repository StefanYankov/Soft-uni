using System;
using System.Collections.Generic;

namespace _07.SoftUniParty
{
    class SoftUniPartyProgram
    {
        static void Main()
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> guests = new HashSet<string>();

            while (true)
            {
                string invitedGuests = Console.ReadLine();

                if (invitedGuests == "PARTY")
                {
                    break;
                }

                if (char.IsDigit(invitedGuests[0]))
                {
                    vipGuests.Add(invitedGuests);
                }
                else
                {
                    guests.Add(invitedGuests);
                }
            }

            while (true)
            {
                string arrivedGuests = Console.ReadLine();

                if (arrivedGuests == "END")
                {
                    break;
                }

                if (vipGuests.Contains(arrivedGuests))
                {
                    vipGuests.Remove(arrivedGuests);
                }
                if (guests.Contains(arrivedGuests))
                {
                    guests.Remove(arrivedGuests);
                }
            }

            int total = vipGuests.Count + guests.Count;

            Console.WriteLine(total);
            foreach (var guest in vipGuests)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
