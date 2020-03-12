using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var entered = new List<IId>();


            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] details = input.Split(" ").ToArray();

                if (details.Length == 3)
                {
                    string name = details[0];
                    int age = int.Parse(details[1]);
                    string id = details[2];
                    Citizen citizen = new Citizen(name,age,id);
                    entered.Add(citizen);
                }
                else if (details.Length == 2)
                {
                    string name = details[0];
                    string id = details[1];
                    Robot robot = new Robot(name, id);
                    entered.Add(robot);
                }

                input = Console.ReadLine();
            }

            string cypher = Console.ReadLine();


            foreach (var enterer in entered.Where(x => x.Id.EndsWith(cypher)))
            {
                Console.WriteLine(enterer.Id);
            }

        }
    }
}
