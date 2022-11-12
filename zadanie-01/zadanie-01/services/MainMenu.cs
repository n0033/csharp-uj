using System;
using zadanie_01.common.models;

namespace zadanie_01.services
{
    public class MainMenu
    {
        private static string GetMainMenuChoiceFromPlayer()
        {
            Console.WriteLine("Witaj w grze 'Gra'");
            Console.WriteLine("[1] Zacznij nową grę");
            Console.WriteLine("[X] Zamknij program");
            string choice = Console.ReadLine();
            while (choice != "1" && choice.ToLower() != "x")
            {
                Console.Clear();
                Console.WriteLine("Nieprawidłowy wybór");
                Console.WriteLine();
                Console.WriteLine("[1] Zacznij nową grę");
                Console.WriteLine("[X] Zamknij program");

                choice = Console.ReadLine();
            }
            Console.Clear();
            return choice;
        }

        private static bool VerifyName(string name)
        {
            bool isLiteral = name.All(ch => Char.IsLetter(ch)
            || Char.IsWhiteSpace(ch));
            bool isLongEnough = name.Length > 1;
            return isLiteral && isLongEnough;
        }

        private static string ValidateName(string name) // expects verified name
        {
            return name.Trim();
        }

        private static string GetHeroNameFromPlayer()
        {
            Console.WriteLine("Wybierz swoje imię:");
            string playerName = Console.ReadLine();
            playerName = ValidateName(playerName);
            while (!VerifyName(playerName))
            {
                Console.Clear();
                Console.WriteLine("Wybrano nieprawidłowe imię. " +
                    "Imię nie może posiadać znaków specjalnych " +
                    "oraz musi byc dłuższe niż jeden znak.");
                Console.WriteLine();
                Console.WriteLine("Wybierz swoje imię:");
                playerName = Console.ReadLine();
                playerName = ValidateName(playerName);
            }
            Console.Clear();
            return playerName;
        }


        private static EHeroClass GetHeroClassFromPlayer(string playerName)
        {
            Console.WriteLine($"Witaj {playerName}!");
            string ? choice;
            EHeroClass? heroClass = null;
            while(heroClass == null)
            {
                Console.WriteLine("Wybierz swoją klasę bohatera:");
                Console.WriteLine("[0] Barbarzyńca");
                Console.WriteLine("[1] Paladyn");
                Console.WriteLine("[2] Amazonka");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        heroClass = EHeroClass.barbarian;
                        break;
                    case "1":
                        heroClass = EHeroClass.paladin;
                        break;
                    case "2":
                        heroClass = EHeroClass.amazon;
                        break;
                    default:
                        heroClass = null;
                        break;
                }
                Console.Clear();
                Console.WriteLine("Nieprawidłowy wybór." +
                    " Wybierz jedną z poniższych.");

            }
            Console.Clear();
            return (EHeroClass)heroClass;
        }

        private static string GetStringEHeroClassRepresentation(EHeroClass heroClass)
        {
            switch (heroClass)
            {
                case EHeroClass.barbarian:
                    return "Barbarzyńca";
                case EHeroClass.paladin:
                    return "Paladyn";
                default:
                    return "Amazonka";

            }
        }


        private static void PrintStartGameSentence(string playerName,
            EHeroClass heroClass)
        {
            string className = GetStringEHeroClassRepresentation(heroClass);

            Console.WriteLine($"{className} {playerName} wyrusza w przygodę...");
        }


        public static Hero? InvokeHeroCreation()
        {
            string choice = MainMenu.GetMainMenuChoiceFromPlayer();
            if (choice == "1")
            {
                string heroName = MainMenu.GetHeroNameFromPlayer();
                EHeroClass heroClass = MainMenu.GetHeroClassFromPlayer(heroName);
                Hero hero = new Hero(heroName, heroClass);
                MainMenu.PrintStartGameSentence(heroName, heroClass);
                Console.WriteLine();
                Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować...");
                Console.ReadKey();
                return hero;
            }
            return null;
            
        }
    }
}

