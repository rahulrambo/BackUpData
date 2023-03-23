using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.PowerOfNumber
{
    public class PowerOfNumber
    {
        public float PowerOfNum(float number1,int number2)
        {
            if(number2 == 0)
            {
                return 1;
            }
            if(number2 == 1)
            {
                return number1;
            }
            return number1*PowerOfNum(number1,number2-1);            
        }
    }
}
