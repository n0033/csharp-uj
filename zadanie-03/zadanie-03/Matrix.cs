using System;
using System.Numerics;
using complex;


namespace matrix
{
    public class Matrix<T>: IFormattable where T : IComparable, IFormattable
    {
        private T[,] _matrix;

        public Matrix(T[,] matrix)
        {
            if (typeof(T) != typeof(int) &&
                typeof(T) != typeof(double) &&
                typeof(T) != typeof(float) &&
                typeof(T) != typeof(Complex<int>) &&
                typeof(T) != typeof(Complex<double>) &&
                typeof(T) != typeof(Complex<float>))
            {
                throw new Exception("Incompatible type.");
            }

            _matrix = matrix;

        }


        public Matrix(int rows, int cols)
        {
            if (typeof(T) != typeof(int) &&
                typeof(T) != typeof(double) &&
                typeof(T) != typeof(float) &&
                typeof(T) != typeof(Complex<int>) &&
                typeof(T) != typeof(Complex<double>) &&
                typeof(T) != typeof(Complex<float>))
            {
                throw new Exception("Incompatible type.");
            }
            _matrix = new T[rows, cols];
        }


        public T this[int i, int j]
        {
            get { return _matrix[i, j]; }
            set { _matrix[i, j] = value; }
        }


        public int GetLength(int num)
        {
            switch (num)
            {
                case 0:
                case 1:
                    return this._matrix.GetLength(num);
                default:
                    throw new IndexOutOfRangeException("Matrix is two-dimensional.");

            }
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            string result = "";
            for (int i = 0; i < GetLength(0); i++)
            {
                for (int j = 0; j < GetLength(1); j++)
                {
                    result += $"{_matrix[i, j]}\t";
                }
                result += "\n";
            }
            return result;
        }




        public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)
        {
            var aRowCount = a.GetLength(0);
            var aColCount = a.GetLength(1);
            var bRowCount = b.GetLength(0);
            var bColCount = b.GetLength(1);

            if (aRowCount != bRowCount || aColCount != bColCount)
            {
                throw new InvalidOperationException("Matrices must be of the same size");
            }

            Matrix<T> result = new Matrix<T>(aRowCount, bColCount);

            for (int row = 0; row < aRowCount; row++)
            {
                for(int col = 0; col < aColCount; col++)
                {
                    dynamic addendOne = a[row, col];
                    dynamic addendTwo = b[row, col];
                    result[row, col] = addendOne + addendTwo;
                }
            }
            return result;
        }


        public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
        {
            var aRowCount = a.GetLength(0);
            var aColCount = a.GetLength(1);
            var bRowCount = b.GetLength(0);
            var bColCount = b.GetLength(1);

            if (aColCount != bRowCount)
                throw new InvalidOperationException
                  ("Cannot multiply such matrices.");

            Matrix<T> product = new Matrix<T>(aRowCount, bColCount);

            for (int aRow = 0; aRow < aRowCount; aRow++)
            {
                for (int bCol = 0; bCol < bColCount; bCol++)
                {
                    for (int aCol = 0; aCol < aColCount; aCol++)
                    {
                        dynamic multiplicant = a[aRow, aCol];
                        dynamic multiplier = b[aCol, bCol];
                        if (product[aRow, bCol] == null)
                        {
                            product[aRow, bCol] = multiplicant * multiplier;
                            continue;
                        }

                        product[aRow, bCol] += multiplicant * multiplier;
                    }
                }
            }

            return product;
        }
    }
}
