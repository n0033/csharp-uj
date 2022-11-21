using System;
using System.Collections.Generic;


namespace zadanie_04_cont
{
    class Task04_2
    {
        public static void execute()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());
            Random rand = new Random();

            List<List<int>> matrix = (new List<int>[n]).ToList();
            
            matrix = (from _ in matrix
                          select (
                          Enumerable.Range(0, m)
                         .Select(r => rand.Next(-100, 100))
                         .ToList()
                          )).ToList();

            int sum = matrix.SelectMany(k => k).Sum();
            Console.WriteLine($"Sum: {sum}");
            matrix.SelectMany(k => k)
                .ToList()
                .ForEach(el => Console.Write($"{el}\t"));


        }
    }
}



