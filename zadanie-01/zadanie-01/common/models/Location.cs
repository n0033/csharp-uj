using System;
using zadanie_01.common.interfaces;
using zadanie_01.common.models;
namespace zadanie_01.services
{
    public class Location
    {
        public Location(string name, NonPlayerCharacter[] npcArray)
        {
            Name = name;
            NpcArray = npcArray;
        }
        public string Name { get; }
        public NonPlayerCharacter[] NpcArray { get; }

        private void PrintMenu()
        {
            for (int i = 0; i < NpcArray.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] Porozmawiaj z {NpcArray[i].Name}");
            }
            Console.WriteLine("[X] Stchórz");
        }

        private void PrintIncorrectChoiceMessage()
        {
            Console.WriteLine("Nieprawidłowy wybór. Wybierz jedno z poniższych: ");
        }


        public NonPlayerCharacter? InvokeNpcChoice()
        {
            int n;
            while (true)
            {
                PrintMenu();
                string choice = Console.ReadLine();
                if (choice.ToLower() == "x") { return null; }
                bool isNumeric = int.TryParse(choice, out n);
                if (!isNumeric || n - 1 >= NpcArray.Length)
                {
                    Console.Clear();
                    PrintIncorrectChoiceMessage();
                    Console.WriteLine();
                    continue;
                }
                break;
            }
            return NpcArray[n - 1];

        }

        public void TalkTo(NonPlayerCharacter npc, IDialogParser dialogParser)
        {
            HeroDialogPart? heroDialog = npc.StartTalking(dialogParser);
            Console.Clear();
            while (heroDialog != null)
            {
                Console.WriteLine(dialogParser.ParseDialog(heroDialog));
                INpcDialogPart? npcDialog = heroDialog.NpcDialogPart;
                if (npcDialog == null) { break; }
                Console.Clear();
                Console.WriteLine(dialogParser.ParseDialog(npcDialog));
                heroDialog = npcDialog.InvokeDialogChoice();
                Console.Clear();
            }
            
        }

    }
}

