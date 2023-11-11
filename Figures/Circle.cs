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
}
