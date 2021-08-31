using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Test.Data.Models;
using Web_Api_Test.Data.ViewModels;

namespace Web_Api_Test.Data.Services
{
    public class AuthorsService
    {
        public AppDbContext _context;

        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorViewModel authorViewModel)
        {
            var _author = new Author()
            {
                Name = authorViewModel.Name
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();

        }

        public AuthorWithBooksViewModel GetAuthorWithBooks(int authorId)
        {
            var author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorWithBooksViewModel()
            {
                Name = n.Name,
                BookTitles = n.Book_Authors.Select(n => n.Book.Title).ToList()
            }).FirstOrDefault();

            return author;
        }
    }
}
