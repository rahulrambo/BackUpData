using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Core.Custom_Exception
{
    public class CustomerNotFoundException:Exception
    {
        public CustomerNotFoundException()
        {

        }
        public CustomerNotFoundException(int id):base(string.Format($"Invalid CustomerId:{id}", id))
        {

        }
    }
}
