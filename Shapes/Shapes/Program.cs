using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{

    abstract class Shape
    {
        //abstract private double _area;
        abstract public double CalcArea();
        //abstract public double Area{ }
    }

    class Rectangle : Shape
    {
        private double _a;
        private double _b;
        private double _area;

        public Rectangle(double a, double b)
        {
            _a = a;
            _b = b;
            _area = CalcArea();
        }

        public double Area { get { return _area; } }
        public double A { get { return _a; } }
        public double B { get { return _b; } }

        public override double CalcArea()
        {
            return _a * _b;
        }

    }

    class Round : Shape
    {
        private double _r;
        private double _area;

        public Round(double r)
        {
            _r = r;
            _area = CalcArea();
        }

        public double Area { get { return _area; } }
        public double R { get { return _r; } }

        public override double CalcArea()
        {
            return Math.PI * Math.Pow(_r, 2);
        }

    }

    class Triangle : Shape
    {
        private double _a;
        private double _b;
        private double _c;
        private double _area;

        public Triangle(double a, double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
            _area = CalcArea();
        }

        public double Area { get { return _area; } }
        public double A { get { return _a; } }
        public double B { get { return _b; } }
        public double C { get { return _c; } }

        public override double CalcArea()
        {
            double p = (_a + _b + _c) / 2;
            return Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = { new Rectangle(4, 3), new Round(3), new Triangle(3, 4, 5) };

            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape.CalcArea());
            }

        }
    }
}
