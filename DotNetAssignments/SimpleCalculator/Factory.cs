using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    internal class Factory
    {
        private IOperation _addition;
        private IOperation _subtraction;
        private IOperation _multiplication;
        private IOperation _division;
        private IOperation _powerOf;
        public IOperation AdditionOperation
        {
            get
            {
                if (_addition == null)
                {
                    _addition = new Addition();
                }
                return _addition;
            }
        }
        public IOperation SubtractionOperation
        {
            get
            {
                if (_subtraction == null)
                {
                    _subtraction = new Subtraction();
                }
                return _subtraction;
            }
        }
        public IOperation MultiplicationOperation
        {
            get
            {
                if (_multiplication == null)
                {
                    _multiplication = new Multiplication();
                }
                return _multiplication;
            }
        }
        public IOperation DivisionOperation
        {
            get
            {
                if (_division == null)
                {
                    _division = new Division();
                }
                return _division;
            }
        }
        public IOperation PowerOfOperation
        {
            get
            {
                if (_powerOf == null)
                {
                    _powerOf = new PowerOf();
                }
                return _powerOf;
            }
        }
    }
}
