using System.ComponentModel.DataAnnotations;

namespace DigitalBank.Business.Models
{
    public class CustomerModel
    {        
        [Required]
        [RegularExpression(@"[a-zA-Z]{3,30}",ErrorMessage ="Please enter a valid Name")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z]{3,30}", ErrorMessage = "Please enter a valid Name")]
        public string Lastname { get; set; }
        [Required]
        [RegularExpression(@"([a-zA-Z] *){3,30}", ErrorMessage = "Please enter a valid Address")]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"([a-zA-Z] *){3,30}", ErrorMessage = "Please enter a valid City")]
        public string City { get; set; }
        [Required]
        [RegularExpression(@"([a-zA-Z] *){3,30}", ErrorMessage = "Please enter a valid District")]
        public string District { get; set; }
        [Required]
        [RegularExpression(@"([a-zA-Z] *){3,30}", ErrorMessage = "Please enter a valid State")]
        public string State { get; set; }
        [Required]
        [RegularExpression(@"\d{6}", ErrorMessage = "Please enter a valid Zip Code")]
        public string ZipCode { get; set; }
        [Required]
        [RegularExpression(@"\d{1,}", ErrorMessage = "Please enter a valid BankId")]
        public int BankId { get; set; }
        [Required]
        [RegularExpression(@"([a-zA-Z]-*\d*){2,50}", ErrorMessage = "Please enter a valid BranchCode")]
        public string BranchCode { get; set; }
        [Required]
        [RegularExpression(@"\d{4,}", ErrorMessage = "Please enter a valid Amount")]
        public decimal Amount { get; set; }
    }
}
