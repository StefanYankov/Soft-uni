namespace P07SoftUniParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class SoftUniPartyProgram
    {
        public static void Main()
        {
            Dictionary<string, HashSet<string>> partyRepository = new Dictionary<string, HashSet<string>>();
            while (true)
            {
                string input = Console.ReadLine();

                if (input.Equals("PARTY"))
                {
                    break;
                }

                bool isVip = char.IsDigit(input[0]);

                if (isVip)
                {
                    if (!partyRepository.ContainsKey("VIP"))
                    {
                        partyRepository.Add("VIP", new HashSet<string>());
                    }

                    partyRepository["VIP"].Add(input);

                }
                else
                {
                    if (!partyRepository.ContainsKey("Regular"))
                    {
                        partyRepository.Add("Regular", new HashSet<string>());
                    }
                    partyRepository["Regular"].Add(input);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input.Equals("END"))
                {
                    break;
                }

                bool isVip = char.IsDigit(input[0]);

                if (isVip)
                {
                    if (partyRepository["VIP"].Contains(input))
                    {
                        partyRepository["VIP"].Remove(input);
                    }
                }
                else
                {
                    if (partyRepository["Regular"].Contains(input))
                    {
                        partyRepository["Regular"].Remove(input);
                    }
                }
            }

            int count = 0;
            if (partyRepository.ContainsKey("VIP"))
            {
                count += partyRepository["VIP"].Count;
            }

            if (partyRepository.ContainsKey("Regular"))
            {
                count += partyRepository["Regular"].Count;
            }
            Console.WriteLine(count);
            foreach (var category in partyRepository.OrderByDescending(k => k.Key))
            {
                if (category.Value.Count > 0)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, category.Value));
                }
            }
        }
    }
}
