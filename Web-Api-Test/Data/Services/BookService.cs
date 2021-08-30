using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Test.Data.Models;
using Web_Api_Test.Data.ViewModels;

namespace Web_Api_Test.Data.Services
{
    public class BookService
    {
        private AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookViewModel bookViewModel)
        {
            var _book = new Book()
            {
                Title = bookViewModel.Title,
                Description = bookViewModel.Description,
                IsRead = bookViewModel.IsRead,
                DateRead = bookViewModel.IsRead ? bookViewModel.DateRead.Value : null,
                Rate = bookViewModel.IsRead ? bookViewModel.Rate.Value : null,
                Genre = bookViewModel.Genre,
                Author = bookViewModel.Author,
                CoverUrl = bookViewModel.CoverUrl,
                DateAdded = DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
           return _context.Books.FirstOrDefault(n => n.Id==id);
        }
    }
}
