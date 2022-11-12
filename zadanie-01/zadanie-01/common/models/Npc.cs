using System;
using zadanie_01.common.interfaces;

namespace zadanie_01.common.models
{
    public class NonPlayerCharacter : INpc
    {
        public NonPlayerCharacter(string name, NpcDialogPart dialogPart)
        {
            Name = name;
            DialogPart = dialogPart;
        }

        public string Name { get; }
        public NpcDialogPart DialogPart { get; }
        public override string ToString() => $"{Name}";

        public HeroDialogPart? StartTalking(IDialogParser dialogParser)
        {
            Console.WriteLine(dialogParser.ParseDialog(DialogPart));
            return DialogPart.InvokeDialogChoice();

        }

    }
}

