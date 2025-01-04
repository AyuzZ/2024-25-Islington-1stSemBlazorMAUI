using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CredWatch.Models
{
    public class Currency
    {
       
        public int CurrencyId { get; set; }

        public string CurrencyName { get; set; }

        public string CurrencyCode { get; set; }

        public Currency(int currencyId, string currencyName, string currencyCode)
        {
            CurrencyId = currencyId;
            CurrencyName = currencyName;
            CurrencyCode = currencyCode;
        }

        public Currency()
        {
        }
    }
}
