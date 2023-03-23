using System;

namespace PracticeForInterview// Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Console.Write("Enter your input for Compressing:");
            //string input=Console.ReadLine();
            //CompressString.Compress(input);

            //FullSequenceOfLetters.FullSequence();

            //Rectangle rectangle = new Rectangle(10, 2);
            //Square square = new Square(5, 2);
            //Console.WriteLine($"Area of Rectangle is:{rectangle.GetArea()}");
            //Console.WriteLine($"Area of Square is:{square.GetArea()}");

            InterfaceConcept concept = new InterfaceConcept();
            concept.Test();
        }
    }
}