namespace P03WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCountProgram
    {
        public static void Main()
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            string[] wordsToSearch = File.ReadAllLines(@"files\words.txt"); // words.txt has "always copy"
            string[] textToSearchIn = File.ReadAllLines(@"files\text.txt"); // text.txt has "always copy"

            foreach (var word in wordsToSearch)
            {
                if (!wordCount.ContainsKey(word.ToLower()))
                {
                    wordCount.Add(word.ToLower(), 0);
                }
            }

            foreach (var line in textToSearchIn)
            {
                string[] words = line.ToLower().Split(new[] { ' ', '.', ',', '-', '?', '!', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    if (wordCount.ContainsKey(word))
                    {
                        wordCount[word]++;
                    }
                }
            }

            List<string> wordCountAsList = new List<string>();

            foreach (var word in wordCount.OrderByDescending(x => x.Value))
            {
                wordCountAsList.Add($"{word.Key} - {word.Value}");
            }

            File.WriteAllLines("actualResult.txt", wordCountAsList);

            // it is not shared how to visualize the comparison, hence I've decided to use the console.
            string[] actualResult= File.ReadAllLines(@"actualResult.txt");
            string[] expectedResult = File.ReadAllLines(@"files\expectedResult.txt"); // expectedResult.txt has "always copy"

            var arraysAreEqual = actualResult.SequenceEqual(expectedResult);

            Console.WriteLine(arraysAreEqual);
        }
    }
}