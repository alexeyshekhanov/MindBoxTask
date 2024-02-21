using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Triangle : IBaseFigure
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
                Validation(A, value, C);
                b = value;
            }
        }
        public double C
        {
            get { return c; }
            set
            {
                Validation(A, B, value);
                c = value;
            }
        }

        public double GetSquare()
        {
            var semiPerimeter = (a + b + c) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));
        }

        public bool IsRightTriangle()
        {
            return a * a + b * b == c * c || a * a + c * c == b * b || b * b + c * c == b * b;
        }

        private void Validation(double a, double b, double c)
        {
            var paramName = String.Empty;

            if (a <= 0)
                paramName = nameof(a);
            else if (b <= 0)
                paramName = nameof(b);
            else if (c <= 0)
                paramName = nameof(c);

            if (paramName.Length != 0)
                throw new ArgumentException("Each side must be above 0", paramName);

            paramName = String.Empty;

            if (b + c <= a)           // неравенство треугольника
                paramName = nameof(a);
            else if (a + c <= b)
                paramName = nameof(b);
            else if (a + b <= c)
                paramName = nameof(c);

            if (paramName.Length != 0)
                throw new ArgumentException("A triangle with these sides doesn't exist or it is degenerative", paramName);
        }
    }
}
