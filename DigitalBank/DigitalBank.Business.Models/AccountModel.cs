using System.ComponentModel.DataAnnotations;

namespace DigitalBank.Business.Models
{
    public class AccountModel
    {        
        public string CustomerName { get; set; }        
        public string BankName { get; set; }
        public string BranchCode { get; set; }        
        public string AccountType { get; set; }        
        public bool IsActive { get; set; }        
        public decimal Balance { get; set; }
    }
}
