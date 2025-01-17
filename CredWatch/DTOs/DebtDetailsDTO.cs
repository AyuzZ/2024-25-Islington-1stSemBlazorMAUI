using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredWatch.DTOs
{
    public class DebtDetailsDTO
    {
        public int TransactionId { get; set; }
        public string Title { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Note { get; set; }
        public string Tag { get; set; }
        public int UserId { get; set; }
        public string Category { get; set; }
        public int DebtId { get; set; }
        public string Source { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCleared { get; set; }

        public DebtDetailsDTO(int transactionId, string title, double amount, DateTime createdDate, string? note, string tag, int userId, string category)
        {
            TransactionId = transactionId;
            Title = title;
            Amount = amount;
            CreatedDate = createdDate;
            Note = note;
            Tag = tag;
            UserId = userId;
            Category = category;
        }

        public DebtDetailsDTO()
        {
        }

    }
}
