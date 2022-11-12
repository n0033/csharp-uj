using System;
using zadanie_01.common.interfaces;
namespace zadanie_01.common.models
{
    public class DialogParser : IDialogParser
    {
        public DialogParser(Hero hero)
        {
            Player = hero;
        }

        public Hero Player { get; }

        public string ParseDialog(IDialogPart dialogPart)
        {
            return dialogPart.GetSentence().Replace("#HERONAME#", Player.Name);
        }
    }
}

