using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.StarPattern
{
    internal class PatternLogic
    {
        public void PrintStar()
        {
            Console.WriteLine("Please enter your choice");
            int num = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                for (int j = i; j < num; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k <= i; k++)
                {
                    if (k > 0 && i < num - 1)
                    {
                        Console.Write(" ");
                        continue;
                    }
                    else if (i == num - 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                for (int l = 1; l <= i; l++)
                {
                    if (i == l && i < num - 1)
                    {
                        Console.Write("*");
                        continue;
                    }
                    else if (i == num - 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
