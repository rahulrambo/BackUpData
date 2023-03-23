using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.FullSequenceOfLetters
{
    internal class Application
    {
        public static void Start(string[] args)
        {
            var fullSequenceOfLetters = new ProgramLogic();            
            fullSequenceOfLetters.SequenceOfLetters();
        }
    }
}
