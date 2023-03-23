using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Core.Custom_Exception
{
    public class AccountNotFoundException:Exception
    {
        public AccountNotFoundException()
        {

        }
        public AccountNotFoundException(int id):base(string.Format($"Invalid AccountId:{id}", id))
        {

        }
    }
}
