using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
       public Task<IList<User?>> GetAllForLoginAsync();
       public IList<User?> GetAllForLogin();

    }
}
