using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeForInterview
{
    public abstract class AbstractConcept
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public abstract double GetArea();
    }
    public class Rectangle : AbstractConcept
    {
        public Rectangle(int Height, int Width)
        {
            this.Width = Width;
            this.Height = Height;
        }
        public override double GetArea()
        {
            return Width * Height;
        }
    }
    public class Square : AbstractConcept
    {
        public Square(int Height,int Width)
        {
            this.Height = Height;
            this.Width = Width;
        }
        public override double GetArea()
        {
            return Height * Width;
        }
    }    
}
