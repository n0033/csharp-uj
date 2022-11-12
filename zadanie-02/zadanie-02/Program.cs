using System;

using zadanie_02.services;

public class MainClass
{

    public static void Main()
    {
        string topic;
        int parliamentarianAmount;
        Console.WriteLine("Podaj temat glosowania:");
        topic = Console.ReadLine();
        Console.WriteLine("Podaj liczbe parlamentarzystów: ");
        while (true)
        {
            try
            {
                string amount = Console.ReadLine();
                parliamentarianAmount = int.Parse(amount);
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Podaj liczbę!");
            }
        }

        Parliament parliament = new Parliament(parliamentarianAmount, topic);
        Console.WriteLine("Wpisz POCZATEK, aby zaczac.");
        string userChoice;
        do
        {
            userChoice = Console.ReadLine();
            if (!userChoice.Equals("POCZATEK"))
            {
                Console.Clear();
                Console.WriteLine("Nieprawidlowy wybor. " +
                    "Wpisz POCZATEK, aby zaczac glosowanie.");
            }

        } while (!userChoice.Equals("POCZATEK"));
        Console.WriteLine($"Parlamentarzysci o numerach od 0 do" +
            $" {parliamentarianAmount - 1} sa gotowi do glosowania.");
        parliament.StartVoting();


        while (true)
        {
            userChoice = Console.ReadLine();
            if (userChoice.Split(" ").Length == 2 && userChoice.Split(" ")[0].Equals("GLOS"))
            {
                try
                {
                    int number = int.Parse(userChoice.Split(" ")[1]);
                    if (number < 0 || number >= parliament.parliamentarians.Length)
                    {
                        Console.WriteLine("Nieprawidlowy numer parlamentarzysty!");
                        continue;
                    }

                    parliament.parliamentarians[number].OnVote(parliament, EventArgs.Empty);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Numer parlamentarzysty musi byc liczba!");
                }
            }
            else if (userChoice.Equals("KONIEC")) {
                parliament.StopVoting();
                break;
            }
            else
            {
                Console.WriteLine("Nieprawidlowy wybor." +
                    " Wybierz KONIEC lub GLOS <number parlamentarzysty>");
            }
        }

    }
}