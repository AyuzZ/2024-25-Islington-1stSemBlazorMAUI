using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredWatch.Models;

namespace CredWatch.Services
{
    public interface IDebtService
    {
        Task SaveDebtAsync(Debt debt);

        Task<Debt> GetDebtByTransactionIdAsync(int transactionId);

        //Task<User> GetUserAsync(string username);
    }
}
