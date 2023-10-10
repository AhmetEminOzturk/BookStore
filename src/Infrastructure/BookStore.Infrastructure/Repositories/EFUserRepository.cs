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
    public class EFUserRepository : IUserRepository
    {
        private readonly BookStoreDbContext _dbContext;

        public EFUserRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task CreateAsync(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var deleting = _dbContext.Users.Find(id);
            _dbContext.Users.Remove(deleting);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var deleting = await _dbContext.Users.FindAsync(id);
            _dbContext.Users.Remove(deleting);
            await _dbContext.SaveChangesAsync();
        }

        public User? Get(int id)
        {
            return _dbContext.Users.SingleOrDefault(x => x.Id == id);
        }

        public IList<User?> GetAll()
        {
            return _dbContext.Users.AsNoTracking().ToList();
        }

        public async Task<IList<User?>> GetAllAsync()
        {
            return await _dbContext.Users.AsNoTracking().ToListAsync();
        }

        public IList<User?> GetAllForLogin()
        {
            return _dbContext.Users.AsNoTracking().ToList();
        }

        public async Task<IList<User?>> GetAllForLoginAsync()
        {
            return await _dbContext.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User?> GetAsync(int id)
        {
            return await _dbContext.Users.AsNoTracking().FirstAsync(p => p.Id == id);
        }

        public bool IsExists(int id)
        {
            return  _dbContext.Users.Any(c => c.Id == id);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _dbContext.Users.AnyAsync(c => c.Id == id);
        }

        public void Update(User entity)
        {
            _dbContext.Users.Update(entity);
            _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(User entity)
        {
            _dbContext.Users.Update(entity);
            await _dbContext.SaveChangesAsync();
        }


    }
}
