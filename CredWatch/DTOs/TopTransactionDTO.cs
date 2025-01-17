using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredWatch.DTOs
{
    public class TopTransactionDTO
    {
        public TopTransactionDTO()
        {
        }

        public int TransactionId { get; set; }

        public string Title { get; set; }

        public double Amount { get; set; }

        public string Category { get; set; }

        public string Tag { get; set; }

        public DateTime CreatedDate { get; set; }

        public TopTransactionDTO(int transactionId, string title, double amount, string category, DateTime createdDate, string tag)
        {
            TransactionId = transactionId;
            Title = title;
            Amount = amount;
            Category = category;
            CreatedDate = createdDate;
            Tag = tag;
        }
    }
}
