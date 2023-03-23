using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Business.Models
{
    public class BaseBankModel
    {
        [Required]
        [RegularExpression(@"\d{1,}", ErrorMessage = "Please enter a valid Bank Id")]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"([a-zA-Z] *){3,50}", ErrorMessage = "Please enter a valid Name")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"([a-zA-Z]-*\d*){2,50}", ErrorMessage = "Please enter a valid Code")]
        public string Code { get; set; }
    }
}
