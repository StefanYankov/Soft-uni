namespace P03WordCount
{
    using System.IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class WordCountProgram
    {
        public static void Main()
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            using StreamReader srWords = new StreamReader(@"..\..\..\words.txt");
            using StreamReader srText = new StreamReader(@"..\..\..\text.txt");

            using StreamWriter sw = new StreamWriter(@"..\..\..\output.txt");
            while (!srWords.EndOfStream)
            {
                var line = srWords.ReadLine().Split(' ');
                foreach (var word in line)
                {
                    var currentWord = word.ToLower();
                    if (!words.ContainsKey(currentWord))
                    {
                        words.Add(currentWord, 0);
                    }
                }
            }

            while (!srText.EndOfStream)
            {
                var line = srText.ReadLine().ToLower().Split(new[] { ' ', '.', ',', '-', '?', '!', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in line)
                {
                    if (words.ContainsKey(word))
                    {
                        words[word]++;
                    }
                }
            }

            foreach (var word in words.OrderByDescending( x => x.Value))
            {
                sw.WriteLine($"{word.Key} - {word.Value}");

            }
        }
    }
}
