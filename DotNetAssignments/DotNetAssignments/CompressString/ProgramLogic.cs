using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.CompressString
{
    public class ProgramLogic
    {
        public void CompressString(string input)
        {            
            string result = string.Empty;
            int j = 0;
            int i = 0;
            int count = 0;
            while (j < input.Length)
            {

                if (input[i] == input[j])
                {
                    count++;
                    j += 1;
                }
                else
                {                    
                    result = $"{result}{input[i]}{count}";
                    i = j;
                    count = 0;
                }
            }
            result = $"{result}{input[i]}{count}";        
            Console.WriteLine(result);
        }
    }
}
