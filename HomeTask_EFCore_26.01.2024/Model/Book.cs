using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_EFCore_26._01._2024.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }

        public override string ToString()
        {
            return $"Id - {Id}, Name - {Title}, Author - {Author}, PageCount - {PageCount}";
        }

        public static Book[] TestData() => new Book[]
        {
            new Book{ Title = "Book1", Author = "Author1", PageCount = 123},
            new Book{ Title = "Book2", Author = "Author2", PageCount = 201},
            new Book{ Title = "Book3", Author = "Author3", PageCount = 178},
            new Book{ Title = "Book4", Author = "Author4", PageCount = 95},
            new Book{ Title = "Book5", Author = "Author5", PageCount = 178},
            new Book{ Title = "Book6", Author = "Author6", PageCount = 178}
        };
    }
}
