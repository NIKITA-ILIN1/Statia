using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statia
{
    internal class Article
    {
        string author { get; set; }
        string title { get; set; }
        DateTime date { get; set; }
        public Article(string author, string title, string date)
        {
            this.author = author;
            this.title = title;
            this.date = Convert.ToDateTime(date);
        }
        public Article() : this("Test", "Test", "Test") { }
        public void PrintArticle()
        {
            Console.Write($"Статья: Автор: {author}, Название: {title}, Дата: {date.ToShortDateString()}");
            Console.WriteLine();
        }
    }
}
