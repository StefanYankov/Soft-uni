using System;
using System.Globalization;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            int familyMembersCount = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < familyMembersCount; i++)
            {
                string[] membersData = Console.ReadLine().Split().ToArray();

                string memberName = membersData[0];
                int memberAge = int.Parse(membersData[1]);

                Person member = new Person(memberName, memberAge);

                family.AddMember(member);
            }

            Person oldestFamilyMember = family.GetOldestMember();

            Console.WriteLine($"{oldestFamilyMember.Name} {oldestFamilyMember.Age}");
        }
    }
}
