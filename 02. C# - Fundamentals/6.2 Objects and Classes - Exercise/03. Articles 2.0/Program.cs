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

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Article> articleList = new List<Article>();
            
            int numCycles = int.Parse(Console.ReadLine());

            for (int i = 0; i < numCycles; i++)
            {
                string[] inputs = Console.ReadLine().Split(", ");

                string title = inputs[0];
                string content = inputs[1];
                string author = inputs[2];

                Article article = new Article(title, content, author);

                articleList.Add(article);
            }

            string command = Console.ReadLine();

            foreach (var currArticle in articleList)
            {
                Console.WriteLine(currArticle);
            }

        }
    }
}