using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace En_tur_på_bibloteket
{

    public enum Publisher
    {
        Gyldendal,
        Benjamin,
    }

    public enum Status
    {
        Avaliable,
        Lend,
    }

    public class Book
    {
        public Book(string title, string author, Publisher publisher, int pages, int age)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            Pages = pages;
            Avaliabliy = Status.Avaliable;
            Age = age;
        }

        public int Id { get; set; }
        public int Age { get; set; }
        public Status Avaliabliy { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Publisher Publisher { get; set; }
        public int Pages { get; set; }


         
        public override string ToString()
        {
            return "ID: " + Id +  " | Titel: " + Title + " | Forfatter: " + Author + " | Forlag: " + Publisher + " | Sider: " + Pages;
         }
    }
}
