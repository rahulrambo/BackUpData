using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Division:IOperation
    {
        public float Calculate(float number1, float number2)
        {
            if (number2 == 0)
            {
                throw new DivideByZeroException("Exception occured because of divide by 0");
            }
            return number1 / number2;
        }
    }
}
