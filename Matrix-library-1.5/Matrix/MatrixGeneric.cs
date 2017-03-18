using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Matrix
{
    public class MatrixGeneric<T>
    {
        private int _width;
        private int _height;
        private T[,] _matrix;
        private IMathCalculator<T> _mathCalculator;

        public MatrixGeneric<T> Check(string[] array, int row, int column, int type)
        {
            string[] tmparray = new string[column];
            string[,] Marray = new string[row,column];
            for (int i = 0; i < row; i++)
            {
                tmparray = array[i].Split(' ');
                for (int j = 0; j < column; j++)
                {
                    Marray[i,j] = tmparray[j];
                    switch (type)
                    {
                        case 1: //string
                            {
                                break;
                            }
                        case 2: // complex
                            {
                                
                                break;
                            }
                        case 3: // matrix
                            {
                                break;
                            }
                        case 4: // double
                            {
                                try
                                {
                                    Convert.ToDouble(Marray[i, j]);
                                }
                                catch (IncorrectInputException)
                                {
                                    throw new IncorrectInputException("Некорректный тип данных!");
                                }
                                break;
                            }
                        default:
                            {
                                throw new IncorrectInputException("Некорректный тип данных!");
                            }
                            
                    }
                }                   
            }            
        }

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

        public static MatrixGeneric<T> FromArray(T[,] array, IMathCalculator<T> mathCalculator)
        {
            return new MatrixGeneric<T>(array, mathCalculator);
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }  

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public T[,] Matrix
        {
            get { return _matrix; }
            set { _matrix = value; }
        }

        public T this[int hIndex, int wIndex]
        {
            get
            {
                try
                { return Matrix[hIndex, wIndex]; }
                catch (OutOfRangeExcep)
                {
                    throw new OutOfRangeExcep("Index out of matrix range");
                }
            }
            set
            {
                try
                { Matrix[hIndex, wIndex] = value; }
                catch (IndexOutOfRangeException)
                {
                    throw new OutOfRangeExcep("Index out of matrix range");
                }
            }
        }

        IMathCalculator<T> MathCalculator
        {
            get { return _mathCalculator; }
            set { _mathCalculator = value; }
        }

        public static MatrixGeneric<T> operator +(MatrixGeneric<T> m1, MatrixGeneric<T> m2)
        {
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
            catch (DifferentSizeException)
            {
                throw new DifferentSizeException("Несовпадение размеров матриц");
            }
            catch (OutOfRangeExcep)
            {
                throw new OutOfRangeExcep("Индекс находится за пределами массива");
            }
        }

        public static MatrixGeneric<T> operator -(MatrixGeneric<T> m1, MatrixGeneric<T> m2)
        {
            try
            {
                MatrixGeneric<T> m = new MatrixGeneric<T>(m1.Width, m1.Height, m1.MathCalculator);
                for (int i = 0; i < m.Height; i++)
                {
                    for (int j = 0; j < m.Width; j++)
                    {
                        m[i, j] = m.MathCalculator.Sub(m1[i, j], m2[i, j]);
                    }
                }
                return m;
            }
            catch (DifferentSizeException)
            {
                throw new DifferentSizeException("Несовпадение размеров матриц");
            }
            catch (OutOfRangeExcep)
            {
                throw new OutOfRangeExcep("Индекс находится за пределами массива");
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
                        for (int inner = 0; inner < m1.Width; inner++)
                        {
                            m[row, col] = m.MathCalculator.Add(m[row, col], m.MathCalculator.Mul(m1[row, inner], m2[inner, col]));
                        }
                    }
                }
                return m;
            }
            catch (DifferentSizeException)
            {
                throw new DifferentSizeException("Несовпадение размеров матриц");
            }
            catch (OutOfRangeExcep)
            {
                throw new OutOfRangeExcep("Индекс находится за пределами массива");
            }
        }

        //public static MatrixGeneric<T> operator /(MatrixGeneric<T> m1, MatrixGeneric<T> m2)
        //{ }

        public static MatrixGeneric<T> operator *(MatrixGeneric<T> m1, T number)
        {
            try
            {
                MatrixGeneric<T> m = new MatrixGeneric<T>(m1.Height, m1.Width, m1.MathCalculator);
                for (int i = 0; i < m.Height; i++)
                {
                    for (int j = 0; j < m.Width; j++)
                    {
                        try
                        {
                            m[i, j] = m.MathCalculator.Mul(m1[i, j], number);
                        }
                        catch (DifferentTypesException)
                        {
                            throw new DifferentTypesException("Несовпадение типов данных. Невозможно выполнить данную операцию");
                        }
                    }
                }
                return m;
            }
            catch (DifferentSizeException)
            {
                throw new DifferentSizeException("Несовпадение размеров матриц");
            }
            catch (OutOfRangeExcep)
            {
                throw new OutOfRangeExcep("Индекс находится за пределами массива");
            }
        }

        public static MatrixGeneric<T> operator /(MatrixGeneric<T> m1, T number)
        {
            try
            {
                MatrixGeneric<T> m = new MatrixGeneric<T>(m1.Height, m1.Width, m1.MathCalculator);
                for (int i = 0; i < m.Height; i++)
                {
                    for (int j = 0; j < m.Width; j++)
                    {
                        try
                        {
                            m[i, j] = m.MathCalculator.Div(m1[i, j], number);
                        }
                        catch (DifferentTypesException)
                        {
                            throw new DifferentTypesException("Несовпадение типов данных. Невозможно выполнить данную операцию");
                        }
                    }
                }
                return m;
            }
            catch (DifferentSizeException)
            {
                throw new DifferentSizeException("Несовпадение размеров матриц");
            }
            catch (OutOfRangeExcep)
            {
                throw new OutOfRangeExcep("Индекс находится за пределами массива");
            }
        }

        public static MatrixGeneric<T> Transpose(MatrixGeneric<T> m)
        {
            if (m.Height != m.Width)
            {
                throw new SquareMatrixExcep("Матрица должна быть квадратная");
            }
            else
            {
                for (int i = 1; i < m.Height; i++)
                {
                    int j = 0;
                    while (j != i)
                    {
                        T temp = m[i, j];
                        m[i, j] = m[j, i];
                        m[j, i] = temp;
                    }
                }
                return m;
            }
        }

        //public static MatrixGeneric<T> Det(MatrixGeneric<T> m)
        //{
            
        //}
    }
}
