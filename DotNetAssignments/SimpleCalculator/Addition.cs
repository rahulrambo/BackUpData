using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Addition:IOperation
    {
        public float Calculate(float number1, float number2)
        {
            return number1 + number2;
        }
    }
}
