using System;
using System.Numerics;

namespace complex
{



    // !!! It is stated in the task that Complex class should accept any type,
    // but for purposes of overloading operators I have limited it to numeric
    // types only
    class Complex<T>: IComparable, IFormattable where T: IComparable, IFormattable
    {

        public Complex(T real, T imaginary)
        {
            if (typeof(T) != typeof(int) &&
                typeof(T) != typeof(float) &&
                typeof(T) != typeof(double))
                throw new Exception("Invalid argument type.");
            
            Real = real;
            Imaginary = imaginary;
        }
        public T Real { get; }
        public T Imaginary { get; }

        public int CompareTo(object? obj)
        {
            if (obj == null)
                return -1;

            if (GetType() != obj.GetType())
                return -1;

            dynamic objComplex = obj;

            if (Real.CompareTo(objComplex.Real) == 0 &&
                Imaginary.CompareTo(objComplex.Imaginary) == 0)
                return 0;


            throw new InvalidOperationException("Unable to compare" +
                " two non-equal complex numbers.");
        }

        public static Complex<double> operator +(T a, Complex<T> b)
        {
            dynamic x = b;

            var real = x.Real + a;
            var imaginary = x.Imaginary;

            return new Complex<double>(real, imaginary);
        }

        public static Complex<T> operator *(T a, Complex<T> b)
        {
            dynamic x = b;

            var real = x.real * a;
            var imaginary = x.imaginary;

            return new Complex<T>(real, imaginary);
        }

        public static Complex<T> operator *(Complex<T> a, T b)
        {
            dynamic x = a;

            var real = x.real * b;
            var imaginary = x.imaginary;

            return new Complex<T>(real, imaginary);
        }


        public static Complex<double> operator +(Complex<T> a, T b)
        {
            dynamic x = a;

            var real = x.Real + b;
            var imaginary = x.Imaginary;

            return new Complex<double>(real, imaginary);
        }

        public static Complex<T> operator +(Complex<T> a, Complex<T> b)
        {
            dynamic x = a, y = b;

            var real = x.Real + b.Real;
            var imaginary = x.Imaginary + b.Imaginary;

            return new Complex<T>(real, imaginary);
        }

        public static Complex<T> operator *(Complex<T> a, Complex<T> b)
        {
            dynamic x = a, y = b;

            var real = x.Real * y.Real - x.Imaginary * y.Imaginary;
            var imaginary = x.Real * y.Imaginary + x.Imaginary * y.Real;

            return new Complex<T>(real, imaginary);
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            return $"{this.Real.ToString()} + i*{this.Imaginary.ToString()}";
        }
    }

}

