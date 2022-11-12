using System;
using zadanie_01.common.models;
namespace zadanie_01.common.interfaces
{
    public interface INpc
    {
        HeroDialogPart? StartTalking(IDialogParser dialogParser);
    }
}

