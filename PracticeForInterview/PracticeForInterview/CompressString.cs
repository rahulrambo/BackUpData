using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeForInterview
{
    internal class CompressString
    {
        public static void Compress(string input)
        {
            string result = string.Empty;
            int i = 0;
            int j = 0;
            int count = 0;
            while (j < input.Length)
            {
                if (input[i] == input[j])
                {
                    count++;
                    j ++;
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
