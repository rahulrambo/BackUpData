using System;
using System.Collections.Generic;

namespace DigitalBank.Entities.Entities
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string TransactionType { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime TransactionTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual Account Account { get; set; } = null!;
    }
}
