using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.Permutation
{
    public class Application
    {
        public static void Start(string[] args)
        {
            var permutation = new ProgramLogic();
            Console.Write("Enter your input to get the permutations:");
            string input=Console.ReadLine();
            int length = input.Length;
            Console.WriteLine("All posible permutations of the array taken are:");
            permutation.PermutationOfArray(input.ToCharArray(), 0, length - 1);
        }
    }
}
