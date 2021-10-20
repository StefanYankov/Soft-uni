namespace P10.PredicateParty_
{
    using System;
    using System.Linq;
    public class PredicatePartyProgram
    {
        public static void Main()
        {
            var guests = Console.ReadLine().Split().ToList();

            Func<string, string, string, bool> filter = (guest, criteria, givenString) =>
               criteria == "StartsWith" ? guest.StartsWith(givenString)
               : criteria == "EndsWith" ? guest.EndsWith(givenString)
               : guest.Length == int.Parse(givenString);

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Party!")
                {
                    break;
                }

                var commands = input.Split();

                var command = commands[0];
                var criteria = commands[1];
                var givenString = commands[2];

                switch (command)
                {
                    case "Remove":
                        guests = guests.Where(x => !filter(x, criteria, givenString)).ToList();
                        break;
                    case "Double":
                        foreach (var guest in guests.Where(x => filter(x, criteria, givenString)).ToList())
                        {
                            var index = guests.IndexOf(guest) + 1;
                            guests.Insert(index, guest);
                        }
                        break;
                }
            }
            if (guests.Any())
            {
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
