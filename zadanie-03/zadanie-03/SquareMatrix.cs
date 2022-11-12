using System;
using System.Numerics;
using complex;
using matrix;


namespace square_matrix
{
    public class SquareMatrix<T> : Matrix<T> where T : IComparable, IFormattable
    {
        private T[,] _matrix;

        public SquareMatrix(T[,] matrix) : base(matrix)
        {
            if (GetLength(0) != GetLength(1))
            {
                throw new Exception("Matrix must be square.");
            }

        }


        public SquareMatrix(int rows, int cols) : base(rows, cols)
        {
            if (GetLength(0) != GetLength(1))
            {
                throw new Exception("Matrix must be square.");
            }
        }


        public bool IsDiagonal()
        {
            for (int i = 0; i < GetLength(0); i++)
            {
                for (int j = 0; j < GetLength(1); j++)
                {
                    if (i != j)
                    {
                        dynamic temp = this[i, j];
                        if (temp != 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
