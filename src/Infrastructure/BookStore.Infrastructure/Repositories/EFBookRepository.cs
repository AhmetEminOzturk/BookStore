using BookStore.Entities;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Repositories
{
    public class EFBookRepository : IBookRepository
    {     
        private readonly BookStoreDbContext _dbContext;

        public EFBookRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Book entity)
        {
            _dbContext.Books.Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task CreateAsync(Book entity)
        {
            await _dbContext.Books.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var deleting = _dbContext.Books.Find(id);
            _dbContext.Books.Remove(deleting);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var deleting = await _dbContext.Books.FindAsync(id);
            _dbContext.Books.Remove(deleting);
            await _dbContext.SaveChangesAsync();
        }

        public Book? Get(int id)
        {
            return _dbContext.Books.SingleOrDefault(x => x.Id == id);
        }

        public IList<Book?> GetAll()
        {
            return _dbContext.Books.AsNoTracking().ToList();
        }

        public async Task<IList<Book?>> GetAllAsync()
        {
            return await _dbContext.Books.AsNoTracking().ToListAsync();
        }

        public async Task<Book?> GetAsync(int id)
        {
            return await _dbContext.Books.AsNoTracking().FirstAsync(p => p.Id == id);
        }

        public IEnumerable<Book> GetBooksByCategory(int categoryId)
        {
            return _dbContext.Books.AsNoTracking().Where(c => c.Category.Id == categoryId).AsEnumerable();
        }

        public async Task<IEnumerable<Book>> GetBooksByCategoryAsync(int categoryId)
        {
            return await _dbContext.Books.AsNoTracking().Where(c => c.Category.Id == categoryId).ToListAsync();
        }

        public bool IsExists(int id)
        {
            return  _dbContext.Books.Any(c => c.Id == id);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _dbContext.Books.AnyAsync(c => c.Id == id);
        }

        public void Update(Book entity)
        {
            _dbContext.Books.Update(entity);
            _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book entity)
        {
            _dbContext.Books.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
