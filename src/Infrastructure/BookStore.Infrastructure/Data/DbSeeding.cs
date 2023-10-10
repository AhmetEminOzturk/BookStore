using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Data
{
    public static class DbSeeding
    {
        public static void SeedDatabase(BookStoreDbContext dbContext)
        {
            seedCategoryIfNotExists(dbContext);
            seedBookIfNotExists(dbContext);

        }

        private static void seedCategoryIfNotExists(BookStoreDbContext dbContext)
        {
            if (!dbContext.Categories.Any())
            {
                var categories = new List<Category>() 
                {
                 new() { Name="TestCategory", },             
                };
                dbContext.Categories.AddRange(categories);
                dbContext.SaveChanges();
            }

        }

        private static void seedBookIfNotExists(BookStoreDbContext dbContext)
        {
            if (!dbContext.Books.Any())
            {
                var courses = new List<Book>()
                {
                    new(){ ImageUrl="https://loremflickr.com/320/240", Title="TestBookTitle", Price=50,   },
                };
                dbContext.Books.AddRange(courses);
                dbContext.SaveChanges();
            }
        }

    }
}
