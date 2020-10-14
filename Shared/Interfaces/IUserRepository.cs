using System.Threading.Tasks;
using Backend.Models;

namespace Shared.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(string username, string password);
    }
}