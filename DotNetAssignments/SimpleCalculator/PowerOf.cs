using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class PowerOf:IOperation
    {
        public float Calculate(float number1, float number2)
        {
            float result = 1;
            for (int i = 0; i < number2; i++)
            {
                result *= number1;
            }
            return result;
        }
    }
}
