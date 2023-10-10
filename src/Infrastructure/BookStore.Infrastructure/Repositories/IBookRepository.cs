using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        public IEnumerable<Book> GetBooksByCategory(int categoryId);

        public Task<IEnumerable<Book>> GetBooksByCategoryAsync(int categoryId);

    }
}
