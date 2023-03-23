using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DotNetAssignments.FullSequenceOfLetters
{
    internal class ProgramLogic
    {
        Regex regex = new Regex(@"^[a-zA-Z]{2}$");
        public void SequenceOfLetters()
        {
        input:
            Console.Write("Enter the String to get the Sequence of letters between them:");
            string inputString = Console.ReadLine();
            if (!regex.IsMatch(inputString))
            {
                Console.WriteLine("Please enter a String of length two characters\n");
                goto input;
            }
            char firstLetter = inputString[0];
            char secondLetter = inputString[1];
            if (firstLetter > secondLetter)
            {
                Console.WriteLine("Letters taken as input should follow Alphabetical order!\n");
                goto input;
            }
            Console.Write($"Letters present between {firstLetter} and {secondLetter} are: ");
            for (int i = firstLetter; i <= secondLetter; i++)
            {
                char characters = Convert.ToChar(i);
                Console.Write(characters);
            }            
        }
    }
}
