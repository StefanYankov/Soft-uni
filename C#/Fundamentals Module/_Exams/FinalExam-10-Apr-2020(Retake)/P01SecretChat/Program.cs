namespace P01SecretChat
{
    using System;
    using System.Text;
    public class Program
    {
        public static void Main()
        {
            string concealedMessage = Console.ReadLine();
            StringBuilder sb = new StringBuilder(concealedMessage);
            string input = string.Empty;

            while (!(input=Console.ReadLine()).Equals("Reveal"))
            {
                string[] instructionsArray = input.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string instruction = instructionsArray[0];
                string subString = string.Empty;
                switch (instruction)
                {
                    case "InsertSpace":
                        int index = int.Parse(instructionsArray[1]);
                        sb.Insert(index, " ");
                        break;
                    case "Reverse":
                        subString = instructionsArray[1];
                        if (!sb.ToString().Contains(subString))
                        {
                            Console.WriteLine("error");
                            continue;
                        }
                        string reversedSubString = Reverse(subString);
                        string result = sb.ToString();
                        result = ReplaceFirstOccurrence(result, subString, "");
                        sb.Clear();
                        sb.Append(result);
                        sb.Append(reversedSubString);

                        break;
                    case "ChangeAll":
                        subString = instructionsArray[1];
                        if (!sb.ToString().Contains(subString))
                        {
                            continue;
                        }

                        string replacement = instructionsArray[2];
                        sb.Replace(subString, replacement);
                        break;
                }
                Console.WriteLine(sb.ToString());
            }
            Console.WriteLine($"You have a new text message: {sb}");
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string ReplaceFirstOccurrence(string source, string toFind, string replacement)
        {
            int Place = source.IndexOf(toFind);
            string result = source.Remove(Place, toFind.Length).Insert(Place, replacement);
            return result;
        }
    }
}
