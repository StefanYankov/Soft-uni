namespace P01PasswordReset
{
    using System;
    using System.Text;
    public class Program
    {
        public static void Main()
        {
            string password = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            string commands = string.Empty;

            while (!(commands = Console.ReadLine()).Equals("Done"))
            {
                var commandArr = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (commandArr[0])
                {
                    case "TakeOdd":
                        for (int i = 1; i < password.Length; i+=2)
                        {
                            sb.Append(password[i]);
                        }

                        password = sb.ToString();
                        Console.WriteLine(password);
                        break;
                    case "Cut":
                        int index = int.Parse(commandArr[1]);
                        int length = int.Parse(commandArr[2]);
                        int startIndex = password.IndexOf(password.Substring(index, length));
                        password = password.Remove(startIndex, length);
                        Console.WriteLine(password);
                        break;
                    case "Substitute":
                        string substring = commandArr[1];
                        string substitute = commandArr[2]; // check if equal?
                        if (!password.Contains(substring))
                        {
                            Console.WriteLine("Nothing to replace!");
                            break;
                        }

                        password = password.Replace(substring, substitute);
                        Console.WriteLine(password);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
