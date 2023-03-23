using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Business.Models
{
    public class BaseAccountModel
    {
        [Required]
        [RegularExpression(@"\d{8,}", ErrorMessage = "Please enter a valid Customer Id")]
        public int CustomerId { get; set; }
        [Required]
        [RegularExpression(@"\d{1,}", ErrorMessage = "Please enter a valid Bank Id")]
        public int BankId { get; set; }
        [Required]
        [RegularExpression(@"\d{1,}", ErrorMessage = "Please enter a valid BranchCode")]
        public int BranchId { get; set; }
        [Required]
        [RegularExpression(@"Salary|Saving|NRI", ErrorMessage = "Please enter a valid Account Type")]
        public string AccountType { get; set; }        
        [Required]
        [RegularExpression(@"\d{4,}", ErrorMessage = "Please enter a valid Amount")]
        public decimal Balance { get; set; }
    }
}
