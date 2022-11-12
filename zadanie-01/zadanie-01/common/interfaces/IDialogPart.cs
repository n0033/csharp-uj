using System;
using zadanie_01.common.models;
namespace zadanie_01.common.interfaces
{
    public interface IDialogPart
    {
        string GetSentence();
    }

    public interface INpcDialogPart : IDialogPart
    {
        HeroDialogPart InvokeDialogChoice();
        void PrintChoices();
    }
}

