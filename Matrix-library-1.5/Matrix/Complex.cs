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
            res.real = (a.real * b.real + a.imaginary * b.imaginary) / (Math.Pow(b.real, 2) + Math.Pow(b.imaginary, 2));
            res.imaginary = (a.imaginary * b.real - a.real * b.imaginary) / (Math.Pow(b.real, 2) + Math.Pow(b.imaginary, 2));
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

        public static Complex ConvertToComplex(string str)
        {
            string[] array = new string[2];
            int i;
            Complex number = new Complex();

            if (str.Contains("+"))   // a+ib, ib+a
            {
                array = str.Split('+');
            }

            else if (str.Contains("-")) // a-ib, ib-a, -a-ib, -ib-a
            {
                if (str.IndexOf("-") != 0)
                {
                    array = str.Split('-');
                    array[1] = "-" + array[1];  //???
                }
                else
                {
                    string tmp = str.Remove(str.IndexOf("-"), 1);
                    if (!tmp.Contains("-"))
                    {
                        array[0] = "-" + tmp;
                    }
                    else
                    {                       
                        array = tmp.Split('-');
                        array[0] = "-" + array[0];
                        array[1] = "-" + array[1];
                    }
                }                
            }

            else  //  a, ib
            {
                array[0] = str;
                array[1] = "0";
            }                        

            if (!array[0].Contains("i")) // убираем i
            {
                number.real += Convert.ToDouble(array[0]);
                i = array[1].IndexOf("i");
                str = array[1].Remove(i, 1);
                number.imaginary += Convert.ToDouble(array[1]);
            }
            else
            {
                i = array[0].IndexOf("i");               
                str = array[0].Remove(i, 1);
                number.imaginary += Convert.ToDouble(array[0]);
                number.real += Convert.ToDouble(array[1]);
            }
            return number;
        }
    }
}
