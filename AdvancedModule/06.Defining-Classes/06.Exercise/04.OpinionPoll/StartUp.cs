using System;

namespace _04.OpinionPoll
{
    class StartUp
    {
        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            PoolOfPeople poolOfPeople = new PoolOfPeople();

            for (int i = 0; i < count; i++)
            {
                string[] inputLine = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = inputLine[0];
                int age = int.Parse(inputLine[1]);

                Person person = new Person(name, age);

                poolOfPeople.AddMember(person);

            }

            var filteredMembers = poolOfPeople.GetFilteredMembers();

            foreach (var member in filteredMembers)
            {
                Console.WriteLine($"{member.Name} - {member.Age}");
            }
        }
    }
}
