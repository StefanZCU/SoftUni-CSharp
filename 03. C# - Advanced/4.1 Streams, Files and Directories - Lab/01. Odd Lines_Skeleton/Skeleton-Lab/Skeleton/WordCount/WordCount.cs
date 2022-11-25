using System.Text;

namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (StreamReader words = new StreamReader(wordsFilePath))
            {
                string[] wordToFind = words.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Dictionary<string, int> wordOccurence = new Dictionary<string, int>();

                for (int i = 0; i < wordToFind.Length; i++)
                {
                    string currentWord = wordToFind[i];
                    wordOccurence.Add(currentWord, 0);
                    using (StreamReader reader = new StreamReader(textFilePath))
                    {
                        string line = reader.ReadLine();

                        while (line != null)
                        {
                            string[] lineArray = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                            for (int k = 0; k < lineArray.Length; k++)
                            {
                                StringBuilder sb = new StringBuilder();

                                for (int j = 0; j < lineArray[k].Length; j++)
                                {
                                    if (char.IsLetter(lineArray[k][j]))
                                    {
                                        sb.Append(lineArray[k][j]);
                                    }
                                }

                                if (sb.ToString().ToLower() == currentWord.ToLower())
                                {
                                    wordOccurence[currentWord]++;
                                }

                                sb.Clear();
                            }
                            line = reader.ReadLine();
                        }
                    }
                }

                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach (var word in wordOccurence.OrderByDescending(x => x.Value))
                    {
                        writer.WriteLine($"{word.Key} - {word.Value}");
                    }
                }
            }
        }
    }
}
