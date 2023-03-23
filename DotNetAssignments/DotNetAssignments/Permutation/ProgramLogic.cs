using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.Permutation
{
    public class ProgramLogic
    {
        public void Swap(ref char first, ref char second)
        {
            char temp;
            temp = first;
            first = second;
            second = temp;
        }
        public void PermutationOfArray(char[] input, int start, int end)
        {            
            int i;
            if (start == end)
            {                
                Console.WriteLine(input);
            }
            else
            {
                for (i = start; i <= end; i++)
                {
                    Swap(ref input[start], ref input[i]);
                    PermutationOfArray(input, start + 1, end);
                    Swap(ref input[start], ref input[i]);
                }
            }
        }
    }
}
