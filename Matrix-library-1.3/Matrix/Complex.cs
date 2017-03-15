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
            return Complex.Sum(a, b);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return Complex.Subtract(a, b);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            return Complex.Multiplication(a, b);
        }

        public static Complex operator /(Complex a, Complex b)
        {
            return Complex.Divide(a, b);
        }

        public override string ToString()
        {
            return String.Format("{0} + i{1}", this.real, this.imaginary);
        }

        public void Print(Complex a)
        {
            Console.Write(a);
        }

        public void PrintLine(Complex a)
        {
            Console.WriteLine(a);
        }
    }
}
