using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeForInterview
{
    internal class FullSequenceOfLetters
    {
        public static void FullSequence()
        {
            Console.Write("Enter string for getting the characters:");
            string str = Console.ReadLine();
            char first = str[0];
            char second = str[1];            
            for (int i = first; i <= second; i++)
            {
                char result=Convert.ToChar(i);
                Console.WriteLine(result);
            }
        }
    }
}
