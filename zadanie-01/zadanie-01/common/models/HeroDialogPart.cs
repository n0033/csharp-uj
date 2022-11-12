using System;
using zadanie_01.common.interfaces;
namespace zadanie_01.common.models
{
    public class HeroDialogPart : IDialogPart
    {
        public HeroDialogPart(string sentence, NpcDialogPart? nextDialogPart)
        {
            Sentence = sentence;
            NpcDialogPart = nextDialogPart;
        }

        public string Sentence { get; }
        public NpcDialogPart? NpcDialogPart { get; }

        public string GetSentence()
        {
            return Sentence;
        }

    }
}

