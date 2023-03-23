using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DigitalBank.Entities.Entities
{
    public partial class Account
    {
        public Account()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BankId { get; set; }
        public int BranchId { get; set; }
        public string AccountType { get; set; } = null!;
        public bool IsActive { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual Bank Bank { get; set; } = null!;
        public virtual BankBranch Branch { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
