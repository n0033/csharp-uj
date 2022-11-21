using System;
namespace zadanie_04_cont
{
    class Task04_3
    {
        public static void execute()
        {
            String line = "";
            List<String> cities = new List<String>();

            while(line.ToLower() != "x")
            {
                line = Console.ReadLine();
                if (line.ToLower() != "x")
                {
                    cities.Add(line);
                }
            }

            var map = cities
                .GroupBy(x => x.First())
                .ToDictionary(
                        x => x.First().First(),
                        x => x.ToList().OrderBy(x => x)
                );

            char character;
            bool keyExists;

            while(true)
            {
                character = Console.ReadKey().KeyChar;


                keyExists = map.TryGetValue(character, out var value);
                if (!keyExists)
                {
                    Console.WriteLine("PUSTE");
                    continue;
                }

                value.ToList().ForEach(el => Console.Write($"{el}\t"));
                Console.Write("\n");
            }
        }
    }
}

