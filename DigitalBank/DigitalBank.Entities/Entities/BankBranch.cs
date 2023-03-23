using System;
using System.Collections.Generic;

namespace DigitalBank.Entities.Entities
{
    public partial class BankBranch
    {
        public BankBranch()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Address1 { get; set; } = null!;
        public string? Address2 { get; set; }
        public string City { get; set; } = null!;
        public string District { get; set; } = null!;
        public string State { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public int BankId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual Bank Bank { get; set; } = null!;
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
