using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometric_figures
{
    interface IPrint
    {
        void Print();
    }

    abstract class Figure : IPrint
    {
        public abstract double Count_area();

        protected string Type;

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }

    }

    class Rectangle : Figure
    {
        protected double _height;
        protected double height
        {
            get { return _height; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                     "height must not be negative");
                _height = value;
            }
        }
        protected double _width;
        protected double width
        {
            get { return _width; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                     "width must not be negative");
                _width = value;
            }
        }


        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
            this.Type = "Rectangle";

        }
        public override double Count_area()
        {
            return height * width;
        }

        public override string ToString()
        {
            return Type + ": height = " + height.ToString() +
                " width = " + width.ToString() + " Area = " + Count_area().ToString();
        }

    }

    class Square : Rectangle
    {
        public Square(double length) : base(length, length)
        {
            Type = "Square";
        }

    }

    class Circle : Figure
    {

        private double _radius;
        protected double radius
        {
            get { return _radius; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                     "radius must not be negative");
                _radius = value;
            }
        }


        public override double Count_area()
        {
            return 3.1415 * _radius * _radius;
        }

        public Circle(double radius)
        {
            this.radius = radius;
            Type = "Circle";
        }
        public override string ToString()
        {
            return Type + ": radius = " + _radius + " Area = " + Count_area();
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(4);
            Square square = new Square(5);
            Rectangle rectangle = new Rectangle(4, 5);
            circle.Print();
            square.Print();
            rectangle.Print();
            Console.ReadLine();
        }
    }
}