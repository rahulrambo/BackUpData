using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.ExtensionMethod
{
    internal static class ExtensionLogic
    {
        public static int Add(this int a, int b)
        {
            return a + b;
        }
        public static int Sub(this int num1, int num2)
        {
            return num1 - num2;
        }
    }
}
