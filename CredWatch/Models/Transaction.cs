using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredWatch.Models
{
    public class Transaction
    {

        public int TransactionId { get; set; }

        public string Title { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Note { get; set; }

        public int TagId { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }

    }
}
