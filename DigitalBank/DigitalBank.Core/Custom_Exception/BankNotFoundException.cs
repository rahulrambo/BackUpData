using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Core.Custom_Exception
{
    public class BankNotFoundException:Exception
    {
        public BankNotFoundException()
        {

        }
        public BankNotFoundException(int id) : base(string.Format($"Invalid Bank Id:{id}", id))
        {

        }
    }
}
