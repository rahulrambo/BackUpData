using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DigitalBank.Entities.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string Address1 { get; set; } = null!;
        public string? Address2 { get; set; }
        public string City { get; set; } = null!;
        public string District { get; set; } = null!;
        public string State { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
