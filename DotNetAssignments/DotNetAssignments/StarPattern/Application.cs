using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.StarPattern
{
    public class Application
    {
        public static void Start(string[] args)
        {
            var pattern = new PatternLogic();
            pattern.PrintStar();
        }
    }
}
