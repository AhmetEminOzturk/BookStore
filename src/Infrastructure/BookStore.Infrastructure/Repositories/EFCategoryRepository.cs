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
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly BookStoreDbContext _dbContext;

        public EFCategoryRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Category entity)
        {
            _dbContext.Categories.Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task CreateAsync(Category entity)
        {
            await _dbContext.Categories.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var deleting = _dbContext.Categories.Find(id);
            _dbContext.Categories.Remove(deleting);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var deleting = await _dbContext.Categories.FindAsync(id);
            _dbContext.Categories.Remove(deleting);
            await _dbContext.SaveChangesAsync();
        }

        public Category? Get(int id)
        {
            return _dbContext.Categories.SingleOrDefault(x => x.Id == id);
        }

        public IList<Category?> GetAll()
        {
            return _dbContext.Categories.AsNoTracking().ToList();
        }

        public async Task<IList<Category?>> GetAllAsync()
        {
            return await _dbContext.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category?> GetAsync(int id)
        {
            return await _dbContext.Categories.AsNoTracking().FirstAsync(p => p.Id == id);
        }

        public bool IsExists(int id)
        {
            return  _dbContext.Categories.Any(c => c.Id == id);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _dbContext.Categories.AnyAsync(c => c.Id == id);
        }

        public void Update(Category entity)
        {
            _dbContext.Categories.Update(entity);
            _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category entity)
        {
            _dbContext.Categories.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
