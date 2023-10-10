using BookStore.Entities;
using BookStore.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User? ValidateUser(string username, string password)
        {
            return _userRepository.GetAllForLogin().SingleOrDefault(u => u.UserName == username && u.Password == password);
        }
    }
}
