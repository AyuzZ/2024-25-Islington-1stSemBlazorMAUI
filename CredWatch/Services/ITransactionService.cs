using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredWatch.Models;

namespace CredWatch.Services
{
    public interface ITransactionService
    {
        Task<int> SaveTransactionAsync(Transaction transaction);

        Task<List<Transaction>> GetUsersTransactionsAsync(int userId);

        //Task<User> GetUserAsync(string username);
    }
}
