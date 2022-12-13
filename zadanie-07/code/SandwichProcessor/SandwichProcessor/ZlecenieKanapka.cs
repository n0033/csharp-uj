using System;
using System.Threading;
using Common;

namespace SandwichProcessor
{
    public class ZlecenieKanapka : IZlecenie
    {
        private static string[] stages = new string[]
        {
            "Wyciagniecie chleba",
            "Wyciagniecie masla",
            "Maslo sie topi",
            "Schowanie chleba"
        };
        public void process(string title)
        {
            Console.WriteLine(title);
            Thread.Sleep(1000);
            for(int i = 0; i < stages.Length; i++)
            {
                Console.WriteLine(stages[i]);
                Thread.Sleep(1000);
            }
        }
    }
}
