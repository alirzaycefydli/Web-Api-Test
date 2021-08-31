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
    }
