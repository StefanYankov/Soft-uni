namespace P03Problem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            int capacity = int.Parse(Console.ReadLine());
            string input = string.Empty;
            Dictionary<string, User> users = new Dictionary<string, User>();

            while (!(input = Console.ReadLine()).Equals("Statistics"))
            {
                var commandsArr = input.Split("=", StringSplitOptions.RemoveEmptyEntries);
                var command = commandsArr[0];
                var userName = string.Empty;
                switch (command)
                {
                    case "Add":
                        userName = commandsArr[1];
                        int sent = int.Parse(commandsArr[2]);
                        int received = int.Parse(commandsArr[3]);
                        if (!users.ContainsKey(userName))
                        {
                            User user = new User(userName,sent, received);
                            users[userName] = user;
                        }
                        break;
                    case "Message":
                        // Message=Berg=Kevin
                        var sender = commandsArr[1];
                        var receiver = commandsArr[2];
                        if (users.ContainsKey(sender) && users.ContainsKey(receiver))
                        {
                            users[sender].Sent++;
                            if (users[sender].Total() >= capacity)
                            {
                                Console.WriteLine($"{sender} reached the capacity!");
                                users.Remove(sender);
                            }

                            users[receiver].Received++;
                            if (users[receiver].Total() >= capacity)
                            {
                                Console.WriteLine($"{receiver} reached the capacity!");
                                users.Remove(receiver);
                            }
                        }

                        break;
                    case "Empty":
                        // Empty=Berry
                        userName = commandsArr[1];
                        if (userName.Equals("All"))
                        {
                            users.Clear();
                            break;
                        }

                        if (users.ContainsKey(userName))
                        {
                            users.Remove(userName);
                        }
                        break;
                }
            }
            Console.WriteLine($"Users count: {users.Count}");
            foreach (var user in users.OrderByDescending(m => m.Value.Received).ThenBy(u => u.Value.Name))
            {
                Console.WriteLine($"{user.Value.Name} - {user.Value.Total()}");
            }

        }
    }

    public class User
    {
        public User(string name, int sent, int received)
        {
            this.Name = name;
            this.Sent = sent;
            this.Received = received;
        }

        public string Name { get; set; }
        public int Sent { get; set; }
        public int Received { get; set; }

        public int Total()
        {
            return Sent + Received;
        }
    }
}
