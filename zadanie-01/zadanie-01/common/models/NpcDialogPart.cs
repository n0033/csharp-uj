using System;
using zadanie_01.common.interfaces;
namespace zadanie_01.common.models
{
    public class NpcDialogPart : INpcDialogPart
    {
        public NpcDialogPart(string sentence, HeroDialogPart[] heroDialogChoices)
        {
            Sentence = sentence;
            HeroDialogChoices = heroDialogChoices;
        }

        public string Sentence { get; }
        public HeroDialogPart[] HeroDialogChoices { get; }

        public void PrintChoices()
        {
            for(int i = 0; i < HeroDialogChoices.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {HeroDialogChoices[i].GetSentence()}");
            }
        }


        private void PrintIncorrectChoiceMessage()
        {
            Console.WriteLine("Nieprawidłowy wybór. Wybierz jedno z poniższych: ");
        }

        public HeroDialogPart? InvokeDialogChoice()
        {
             
            if (HeroDialogChoices.Length == 0) {
                Console.WriteLine("\nKliknij dowolny przycisk by kontynuować...");
                Console.ReadKey();
                return null;
            }
            int n;
            while (true)
            {
                PrintChoices();
                string choice = Console.ReadLine();
                bool isNumeric = int.TryParse(choice, out n);
                if (!isNumeric || n - 1 >= HeroDialogChoices.Length)
                {
                    Console.Clear();
                    PrintIncorrectChoiceMessage();
                    Console.WriteLine();
                    continue;
                }
                break;
            }
            return HeroDialogChoices[n - 1];

        }


        public string GetSentence()
        {
            return Sentence;
        }
    }
}

