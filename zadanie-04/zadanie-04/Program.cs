using System;


namespace zadanie_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            IEnumerable<int> range = Enumerable.Range(1, n);

            var result = (from num in range
                         where (num != 5) &&
                               (num != 9) &&
                               (num % 2 != 0 || num % 7 == 0)
                         orderby num
                         select Math.Pow(num, 2)).ToArray();

            Console.WriteLine($"Sum:\t{result.Sum()}");
            Console.WriteLine($"Amount of elements:\t{result.Length}");

            if (result.Length > 0)
            {
            Console.WriteLine($"First element:\t{result[0]}");
            Console.WriteLine($"Last element:\t{result[result.Length - 1]}");
            }

            if (result.Length > 2)
            {
                Console.WriteLine($"Third element:\t{result[2]}");
            }




        }
    }
}



