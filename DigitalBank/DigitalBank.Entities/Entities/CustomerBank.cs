using DigitalBank.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Entities.Entities
{
    public class CustomerBank
    {                        
        public int BankId { get; set; }
        public int AccountId { get; set; }
        public int BranchId { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }

        public virtual Bank Bank { get; set; }
        public virtual BankBranch BankBranch { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Account Account { get; set; }
    }
}
