using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DigitalBank.Core;

namespace DigitalBank.Core
{
    public class Validations
    {        
        Regex AlphabetOnlyRegex = new Regex(Constants.AlphabetOnlyRegex);
        public void ValidateName(ref string name)
        {
        validation:
            if (!AlphabetOnlyRegex.IsMatch(name))
            {
                Console.WriteLine("Please enter a valid Name");
                name = Console.ReadLine();
                goto validation;
            }
        }
    }
}
