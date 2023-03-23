using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DigitalBank.Entities.Entities
{
    public partial class Bank
    {
        public Bank()
        {
            Accounts = new HashSet<Account>();
            BankBranches = new HashSet<BankBranch>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<BankBranch> BankBranches { get; set; }
    }
}
