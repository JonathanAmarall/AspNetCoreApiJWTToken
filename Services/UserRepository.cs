using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.Interfaces;

namespace Backend.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public User GetUser(string username, string password)
        {
            return _context.Users
                .Where(u => u.Username == username && u.Password == password)
                .FirstOrDefault();
        }
    }
}