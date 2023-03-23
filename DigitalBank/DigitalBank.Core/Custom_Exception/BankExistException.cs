using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Core.Custom_Exception
{
    public class BankExistException:Exception
    {
        public BankExistException()
        {

        }
        public BankExistException(string name,string code):base(string.Format($"Already bank exist having name as:{name} or Code as:{code}"))
        {

        }
    }
}
