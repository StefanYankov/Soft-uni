namespace P03SoftUniBarIncome
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Regex regex = new Regex(@"(^:?[^|$%.]*%(?<customer>[A-z][a-z]+)%:?[^|$%.]*<(?<product>\w+)>:?[^|$%.]*\|(?<quantity>\d+):?[^|$%.]*\|:?[^|$%.^\d]*(?<price>\d+.?\d*)\$$)");
            double totalIncome = 0;

            while (!input.Equals("end of shift"))
            {
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string customerName = match.Groups["customer"].Value;
                    string product = match.Groups["product"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    double totalPrice = quantity * price;
                    totalIncome += totalPrice;
                    Console.WriteLine($"{customerName}: {product} - {totalPrice:F2}");
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
}
