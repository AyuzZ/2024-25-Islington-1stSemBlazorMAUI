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

        public double Amount { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? Note { get; set; }
         
        // to change to int (after seeding default value works)
        public string Tag { get; set; }

        public int UserId { get; set; }

        // to change to int (after seeding default value works)
        public string Category { get; set; }

    }
}
