using System;
using complex;
using matrix;
using queue;
using square_matrix;

namespace zadanie_03
{
    public class Task3
    {


        static void Main(string[] args)
        {
            Queue myQueue = new Queue();

            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            Console.WriteLine(myQueue.Dequeue());
            Console.WriteLine(myQueue.Dequeue());

            Complex<int> myComplex = new Complex<int>(5, 3);
            Console.WriteLine(myComplex.Real);
            Console.WriteLine(myComplex.Imaginary);

            Complex<int> myComplex2 = new Complex<int>(3, 2);
            Console.WriteLine(myComplex);
            Console.WriteLine(myComplex2);
            Console.WriteLine(myComplex + myComplex2);
            var result = myComplex + myComplex2;
            Console.WriteLine(result);



            int[,] arrayOne = new int[,] { { 1, 2 }, { 3, 4 } };
            int[,] arrayTwo = new int[,] { { 5, 6 }, { 7, 8 } };

            Matrix<int> matrixOne = new Matrix<int>(arrayOne);
            Matrix<int> matrixTwo = new Matrix<int>(arrayTwo);

            Console.WriteLine(matrixOne);
            Console.WriteLine(matrixTwo);

            Console.WriteLine(matrixOne + matrixTwo);
            Console.WriteLine(matrixOne * matrixTwo);



            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(arrayOne);
            Console.WriteLine(squareMatrix.IsDiagonal()); // false

            squareMatrix[0, 1] = 0;
            squareMatrix[1, 0] = 0;

            Console.WriteLine(squareMatrix.IsDiagonal()); // true


            Complex<int>[,] complexArrayOne = new Complex<int>[,] {
                { new Complex<int>(1, 2), new Complex<int>(3, 4) },
                { new Complex<int>(5, 6), new Complex<int>(7, 8) } };

            Complex<int>[,] complexArrayTwo = new Complex<int>[,] {
                { new Complex<int>(9, 10), new Complex<int>(11, 12) },
                { new Complex<int>(13, 14), new Complex<int>(15, 16) } };

            Matrix<Complex<int>> complexMatrixOne = new Matrix<Complex<int>>(complexArrayOne);
            Matrix<Complex<int>> complexMatrixTwo = new Matrix<Complex<int>>(complexArrayTwo);

            Console.WriteLine(complexMatrixOne + complexMatrixTwo);
            Console.WriteLine(complexMatrixOne * complexMatrixTwo);


        }
        
    }
}

