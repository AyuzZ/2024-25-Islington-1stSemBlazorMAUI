using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredWatch.Models;

namespace CredWatch.Services
{
    public interface ICurrencyService
    {
        Task SaveCurrencyAsync(Currency currency);

        Task<List<Currency>> GetAllCurrenciesAsync();
    }
}
