using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.BitsToNumAndViceVersa
{
    internal class ProgramLogic
    {
        public void NumberToBits(int number)
        {
            StringBuilder result = new StringBuilder();
            Console.Write($"The Value of {number} in Bits is: ");
            while (number > 0)
            {
                result.Append(number % 2);
                number /= 2;
            }
            string str = result.ToString();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                Console.Write(str[i]);
            }
            Console.WriteLine();
        }
        public void BitsToNumber(int input)
        {
            string str1 = input.ToString();
            int result = 0;
            int mul = 1;
            int value;
            for (int i = str1.Length - 1; i >= 0; i--)
            {
                value = int.Parse(str1[i].ToString());
                result += mul * value;
                mul *= 2;
            }
            Console.WriteLine($"The value of {input} in bits is:{result}");
        }
    }
}
