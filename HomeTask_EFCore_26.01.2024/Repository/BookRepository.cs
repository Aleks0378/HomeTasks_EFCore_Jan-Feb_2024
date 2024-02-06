using HomeTask_EFCore_26._01._2024.Data;
using HomeTask_EFCore_26._01._2024.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_EFCore_26._01._2024.Repository
{
    internal class BookRepository
    {
        private int pageSize = 5;
        private readonly ApplicationContext _context;

        public BookRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void EnsurePopulate()
        {
            if (!_context.Books.Any())
            {
                _context.Books.AddRange(Book.TestData());
                _context.SaveChanges();
            }
        }
        public IEnumerable<Book> GetBooks(int page=1) 
        {
            return _context.Books.Skip(pageSize*(page-1)).Take(pageSize).ToList();
        }
        public Book GetBook(int id)
        {
            return _context.Books.FirstOrDefault(e => e.Id == id);
        }
    }
}
