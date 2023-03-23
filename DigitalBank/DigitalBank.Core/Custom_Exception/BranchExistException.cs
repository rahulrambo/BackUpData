using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DigitalBank.Core.Custom_Exception
{
    public class BranchExistException:Exception
    {
        public BranchExistException()
        {
        }
        public BranchExistException(string code): base(string.Format($"Already Branch exists having Code as:{code}", code))
        {

        }
    }
}
