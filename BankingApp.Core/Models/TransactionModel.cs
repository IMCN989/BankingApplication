using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Core.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } = string.Empty; // e.g., "credit" or "debit"
        public string Description { get; set; } = string.Empty;
        public DateTime TransactionDate { get; set; }
    }
}
