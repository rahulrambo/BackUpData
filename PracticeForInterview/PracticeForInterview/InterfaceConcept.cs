using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeForInterview
{
    // The below one is for Multiple Inheritance using Interface 
    public interface Interface1
    {
        public void Test();
    }
    public interface Interface2
    {
        public void Test();
    }
    internal class InterfaceConcept : Interface1, Interface2
    {
        //The below one is for getting the common method for both which will work separately for both interface 
        public void Test()
        {
            Console.WriteLine("Multiple Inheritance is executing using Interface");
        }

        //The below one is for getting the separate methods for separate interface
        //void Interface1.Test()
        //{
        //    Console.WriteLine("Interface1 is running");
        //}
        //void Interface2.Test()
        //{
        //    Console.WriteLine("Interface2 is running");
        //}
    }    
}
