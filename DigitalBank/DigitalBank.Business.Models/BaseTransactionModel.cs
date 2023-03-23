using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Business.Models
{
    public class BaseTransactionModel
    {
        [Required]
        [RegularExpression(@"\d{1,}", ErrorMessage = "Please enter a valid Account Id")]
        public int AccountId { get; set; }
        [Required]
        [RegularExpression(@"Withdraw|Deposit", ErrorMessage = "Please enter a valid Transaction Type")]
        public string TransactionType { get; set; }
        [Required]
        [RegularExpression(@"\d{3,}", ErrorMessage = "Please enter a valid Amount")]
        public decimal Amount { get; set; }
    }
}
