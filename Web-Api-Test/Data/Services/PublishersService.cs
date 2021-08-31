using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Test.Data.Models;
using Web_Api_Test.Data.ViewModels;

namespace Web_Api_Test.Data.Services
{
    public class PublishersService
    {
        public AppDbContext _context;

        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherViewModel publisherViewModel)
        {
            var _publisher = new Publisher()
            {
                Name = publisherViewModel.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }

        public PublisherWithBooksAndAuthorsViewModel GetPublisherData(int publisherId)
        {
            var data = _context.Publishers.Where(n => n.Id == publisherId).Select(n => new PublisherWithBooksAndAuthorsViewModel()
            {
                Name = n.Name,
                BookAuthors = n.Books.Select(n => new BookAuthorViewModel()
                {
                    BookName = n.Title,
                    BookAuthors = n.Book_Authors.Select(n => n.Author.Name).ToList()
                }).ToList()
            }).FirstOrDefault();

            return data;
        }

        public void DeletePublisherById(int id)
        {
            var publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
                _context.SaveChanges();
            }
        }
    }
}
