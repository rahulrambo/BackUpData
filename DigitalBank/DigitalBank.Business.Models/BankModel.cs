using System.ComponentModel.DataAnnotations;

namespace DigitalBank.Business.Models
{
    public class BankModel
    {        
        [Required]
        [RegularExpression(@"([a-zA-Z] *){3,50}", ErrorMessage = "Please enter a valid Name")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"([a-zA-Z]-*\d*){2,50}", ErrorMessage = "Please enter a valid Code")]
        public string Code { get; set; }
        [Required]
        [RegularExpression(@"([a-zA-Z]-*\d*){2,50}", ErrorMessage = "Please enter a valid Code")]
        public string BranchCode { get; set; }
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
    }
}
