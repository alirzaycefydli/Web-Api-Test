using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Test.Data.Models;

namespace Web_Api_Test.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "First Book Title",
                        Description = "First Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Bigraphy",
                        Author = "First Author",
                        CoverUrl = "https//..",
                        DateAdded = DateTime.Now
                    },
                    new Book()
                    {
                        Title = "Second Book Title",
                        Description = "Second Book Description",
                        IsRead = false,
                        Genre = "Horror",
                        Author = "Second Author",
                        CoverUrl = "https//..",
                        DateAdded = DateTime.Now
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
