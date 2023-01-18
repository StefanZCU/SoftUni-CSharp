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
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            using (var words = new StreamReader(wordsFilePath))
            {
                string line;
                while ((line = words.ReadLine()) != null)
                {
                    string[] lineArr = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < lineArr.Length; i++)
                    {
                        if (!wordCounts.ContainsKey(lineArr[i]))
                        {
                            wordCounts.Add(lineArr[i], 0);
                        }
                    }
                }
            }

            using (var reader = new StreamReader(textFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] lineArr = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < lineArr.Length; i++)
                    {
                        StringBuilder sb = new StringBuilder();

                        for (int j = 0; j < lineArr[i].Length; j++)
                        {
                            if (char.IsLetter(lineArr[i][j]))
                            {
                                sb.Append(lineArr[i][j]);
                            }
                        }

                        if (wordCounts.ContainsKey(sb.ToString().ToLower()))
                        {
                            wordCounts[sb.ToString().ToLower()]++;
                        }

                        sb.Clear();
                    }
                }
            }

            using (var writer = new StreamWriter(outputFilePath))
            {
                foreach (var word in wordCounts.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }

            }


        }
    }
}
