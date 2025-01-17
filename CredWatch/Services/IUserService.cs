using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredWatch.Models;
using CredWatch.DTOs;

namespace CredWatch.Services
{
    public interface IUserService
    {
        Task SaveUserAsync(UserSignupDTO userSignupDTO);

        Task<List<User>> GetAllUsersAsync();

        //Task<User> GetUserAsync(string username);
    }
}
