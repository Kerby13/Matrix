using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    struct Complex
    {
        public double real, imaginary;       

        public static Complex Sum(Complex a, Complex b)
        {
            Complex res = new Complex();
            res.real = a.real + b.real;
            res.imaginary = a.imaginary + b.imaginary;
            return res;
        }

        public static Complex Divide(Complex a, Complex b)
        {
            Complex res = new Complex();
            res.real = (a.real * b.real + a.imaginary * b.imaginary)/(Math.Pow(b.real,2) + Math.Pow(b.imaginary,2));
            res.imaginary = (a.imaginary * b.real - a.real * b.imaginary)/(Math.Pow(b.real,2) + Math.Pow(b.imaginary,2));
            return res;
        }

        public static Complex Multiplication(Complex a, Complex b)
        {
            Complex res = new Complex();
            res.real = a.real * b.real - a.imaginary * b.imaginary;
            res.imaginary = a.imaginary * b.real + a.real * b.imaginary;
            return res;
        }

        public static Complex Subtract(Complex a, Complex b)
        {
            Complex res = new Complex();
            res.real = a.real - b.real;
            res.imaginary = a.imaginary - b.imaginary;
            return res;
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return Sum(a, b);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return Subtract(a, b);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            return Multiplication(a, b);
        }

        public static Complex operator /(Complex a, Complex b)
        {
            try
            {
                return Divide(a, b);
            }
            catch (DivedeByZeroExcep)
            {
                throw new DivedeByZeroExcep("Деление на ноль");
            }
        }

        public static implicit operator Complex(double i)
        {
            Complex number = new Complex();
            number.real = i;
            number.imaginary = 0;

            return number;
        }

        public override string ToString()
        {
            return string.Format("{0} + i{1}", this.real, this.imaginary);
        }
    }
}
