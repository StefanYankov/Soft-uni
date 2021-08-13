namespace P02FancyBarcodes
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    public class Program
    {
        public static void Main()
        {
            string pattern = @"^@#+(?<inner>[A-Z]{1}[A-Za-z0-9]{4,}[A-Z]{1})@#+";
            int numberOfBarcodes = int.Parse(Console.ReadLine());


            for (int i = 1; i <= numberOfBarcodes; i++)
            {
                string barcode = Console.ReadLine();
                MatchCollection match = Regex.Matches(barcode, pattern);
                if (match.Count == 0)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }

                string productGroup = new String(barcode.Where(Char.IsDigit).ToArray());
                if (productGroup.Length == 0)
                {
                    productGroup = "00";
                }
                Console.WriteLine($"Product group: {productGroup}");
            }
        }
    }
}
