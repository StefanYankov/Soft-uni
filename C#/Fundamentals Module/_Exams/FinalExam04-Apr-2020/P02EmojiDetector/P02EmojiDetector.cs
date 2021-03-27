using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace P02EmojiDetector
{
    public class P02EmojiDetector
    {
        public static void Main()
        {
            List<string> emojiList = new List<string>();
            string text = Console.ReadLine();
            long coolThreshold = 1;
            Regex regex = new Regex(@"(::|\*\*)(?<location>[A-Z][A-Za-z]{2,})\1");

            var matches = Regex.Matches(text, @"(::|\*\*)(?<location>[A-Z][a-z]{2,})\1");


            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsDigit(text[i]))
                {
                    long tempChar = (long)Char.GetNumericValue(text[i]);
                    coolThreshold *= tempChar;
                }
            }


            foreach (Match match in matches)
            {
                string tempMatch = match.ToString();
                int length = tempMatch.Length;
                emojiList.Add(tempMatch.Substring(0, length));
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cool threshold: {coolThreshold}")
                .AppendLine($"{emojiList.Count} emojis found in the text. The cool ones are:");
            foreach (var emoji in emojiList)
            {
                var sum = emoji.Where(ch => Char.IsLetter(ch)).Sum(ch => (int)ch);
                if (sum >= coolThreshold)
                {
                    sb.AppendLine(emoji);
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
