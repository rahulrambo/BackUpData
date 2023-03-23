using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DigitalBank.Core.Custom_Exception
{
    public class BranchNotFoundException:Exception
    {
        public BranchNotFoundException()
        {

        }
        public BranchNotFoundException(int id):base(string.Format($"Invalid BranchId:{id}", id))
        {

        }
        public BranchNotFoundException(string code):base(string.Format($"Invalid BranchCode:{code}", code))
        {

        }
    }
}
