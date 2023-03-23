using System;

namespace SimpleCalculator
{
    public interface IOperation
    {
        public float Calculate(float number1, float number2);
    }
}