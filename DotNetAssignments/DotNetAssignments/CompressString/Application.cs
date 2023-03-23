using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.CompressString
{
    public class Application
    {
        public static void Start(string[] args)
        {
            var compressString = new ProgramLogic();
            Console.WriteLine("Enter your input for compressing the String");
            string input = Console.ReadLine();
            compressString.CompressString(input);
        }
    }
}
