using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredWatch.Models;

namespace CredWatch.Services
{
    public interface IUserService
    {
        Task SaveUserAsync(User user);

        Task<List<User>> GetAllUsersAsync();

        Task<User> GetUserAsync();
    }
}
