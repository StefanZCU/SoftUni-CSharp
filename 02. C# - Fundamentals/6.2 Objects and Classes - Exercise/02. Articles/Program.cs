using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Program
{
    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(", ");

            string title = inputs[0];
            string content = inputs[1];
            string author = inputs[2];

            Article article = new Article(title, content, author);

            int numCycles = int.Parse(Console.ReadLine());

            for (int i = 0; i < numCycles; i++)
            {
                string[] input = Console.ReadLine().Split(": ");

                if (input[0] == "Edit")
                {
                    article.Content = input[1];
                }
                else if (input[0] == "ChangeAuthor")
                {
                    article.Author = input[1];
                }
                else if (input[0] == "Rename")
                {
                    article.Title = input[1];
                }
            }

            Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
        }
    }
}