using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class MatrixGeneric<T>
    {
        private int _width;
        private int _height;
        private T[,] _matrix;
        private IMathCalculator<T> _mathCalculator;

        public MatrixGeneric(T[,] array, IMathCalculator<T> mathCalculator)
        {
            Matrix = array;
            Width = array.GetLength(1);
            Height = array.GetLength(0);
            MathCalculator = mathCalculator;
        }
        
        public MatrixGeneric(int width, int height, IMathCalculator<T> mathCalculator)
        {
            Width = width;
            Height = height;
            Matrix = new T[height, width];
            MathCalculator = mathCalculator;
        }

        static MatrixGeneric<T> FromArray(T[,] array, IMathCalculator<T> mathCalculator)
        {
            //MatrixGeneric<T> m = new MatrixGeneric<T>(array);
            return new MatrixGeneric<T>(array, mathCalculator);
        }

        int Width
        {
            get { return _width; }
            set { _width = value; }
        }  

        int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        T[,] Matrix
        {
            get { return _matrix; }
            set { _matrix = value; }
        }

        T this[int hIndex, int wIndex]// TODO: make exceptions and try-catch
        {
            get
            {
                try
                { return Matrix[hIndex, wIndex]; }
                catch (IndexOutOfRangeException) { throw new IndexOutOfRangeException("Index out of matrix range"); }
            }
            set
            {
                try
                { Matrix[hIndex, wIndex] = value; }
                catch (IndexOutOfRangeException) { throw new IndexOutOfRangeException("Index out of matrix range"); }
            }
        }

        IMathCalculator<T> MathCalculator
        {
            get { return _mathCalculator; }
            set { _mathCalculator = value; }
        }

        public static MatrixGeneric<T> operator +(MatrixGeneric<T> m1, MatrixGeneric<T> m2)
        {
            //if (m1.Width == m2.Width && m1.Height == m2.Height)
            //{
            try
            {
                MatrixGeneric<T> m = new MatrixGeneric<T>(m1.Width, m1.Height, m1.MathCalculator);
                for (int i = 0; i < m.Height; i++)
                {
                    for (int j = 0; j < m.Width; j++)
                    {
                        m[i, j] = m.MathCalculator.Add(m1[i, j], m2[i, j]);
                    }
                }
                return m;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
            //}
        }

        public static MatrixGeneric<T> operator -(MatrixGeneric<T> m1, MatrixGeneric<T> m2)
        {
            //if (m1.Width == m2.Width && m1.Height == m2.Height)
            try
            {
                MatrixGeneric<T> m = new MatrixGeneric<T>(m1.Width, m1.Height, m1.MathCalculator);
                for (int i = 0; i < m.Height; i++)
                {
                    for (int j = 0; j < m.Width; j++)
                    {
                        m[i, j] = m.MathCalculator.Div(m1[i, j], m2[i, j]);
                    }
                }
                return m;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public static MatrixGeneric<T> operator *(MatrixGeneric<T> m1, MatrixGeneric<T> m2)
        {
            try
            {
                MatrixGeneric<T> m = new MatrixGeneric<T>(m1.Height, m2.Width, m1.MathCalculator);
                for (int row = 0; row < m.Height; row++)
                {
                    for (int col = 0; col < m.Width; col++)
                    {
                        // Multiply the row of A by the column of B to get the row, column of product.  
                        for (int inner = 0; inner < m1.Width; inner++)
                        {
                            m[row, col] = m.MathCalculator.Add(m[row, col], m.MathCalculator.Mul(m1[row, inner], m2[inner, col]));
                        }
                    }
                }
                return m;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        static MatrixGeneric<T> operator /(MatrixGeneric<T> m1, MatrixGeneric<T> m2)
        { }
    }
}
