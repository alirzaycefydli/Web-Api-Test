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
    }
}
