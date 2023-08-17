using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Circle: IBaseFigure
    {
        private double radius;

        public Circle(double r) 
        {
            Validation(r);
            radius = r;

        }

        public double Radius
        { 
            get { return radius; } 
            set 
            {
                Validation(value);
                radius = value;
            } 
        }

        public double GetSquare()
        {
            return Math.PI * radius * radius;
        }

        private void Validation(double value)
        {
            if (value <= 0)
                throw new ArgumentException("The radius is invalid");
        }
    }

    public class Triangle: IBaseFigure
    {
        private double a, b, c;

        public Triangle(double a, double b, double c)
        {
            Validation(a, b, c);
            this.a = a; 
            this.b = b; 
            this.c = c;
        }

        public double A
        {
            get { return a; }
            set
            {
                Validation(value, B, C);
                a = value;
            }
        }
        public double B
        {
            get { return b; }
            set
            {
                Validation(value, A, C);
                b = value;
            }
        }
        public double C
        {
            get { return c; }
            set
            {
                Validation(value, B, A);
                c = value;
            }
        }

        public double GetSquare()
        {
            var semiPerimeter = (a + b + c) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));
        }

        public bool isRightTriangle()
        {
            if (a * a + b * b == c * c || a * a + c * c == b * b || b * b + c * c == b * b) 
                return true;
            return false;
        }

        private void Validation(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("Each side must be above 0");
            if (a + b <= c || a + c <= b || b + c <= a)
                throw new ArgumentException("A triangle with these sides doesn't exist");
        } 
    }
}
