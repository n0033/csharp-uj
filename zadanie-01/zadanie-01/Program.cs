using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using zadanie_01.common.models;
using zadanie_01.services;

public class MainClass
{
    public static void ShowLocation(Location location)
    {
        Console.WriteLine($"Znajdujesz się w {location.Name}.");
        Console.WriteLine("Co chcesz zrobić?\n");
     }

    public static void Main()
    {
        Hero? hero = MainMenu.InvokeHeroCreation();
        if (hero == null)
        {
            return;
        }
        Console.Clear();

        HeroDialogPart[] blankList = { };
        HeroDialogPart[] heroDialog2Parts2 = { new HeroDialogPart("Się robi szefie.", null), new HeroDialogPart("Goń się Gomez.", null) };
        HeroDialogPart[] heroDialog2Parts1 = {
            new HeroDialogPart("Potrzebuje pieniędzy Gomez. Daj mi kasę.", new NpcDialogPart("Myślisz że możesz tutaj sobie tak przyjść i żebrać? Goń się niewolniku.", blankList)),
            new HeroDialogPart("Przyszedłem położyć kres twoim okrutnym rządom.", new NpcDialogPart("xD <zabija>", blankList)),
            new HeroDialogPart("Chciałbym wykonać dla cb zadanie za darmo.", new NpcDialogPart("Ooo. Przynieś mi zbroję najemnika z nowego obozu.", heroDialog2Parts2))};


        NpcDialogPart npcDialogPart2 = new NpcDialogPart("Niewolniku, #HERONAME#, " +
            "czego tu szukasz?", heroDialog2Parts1);


        HeroDialogPart[] heroDialogParts3 = {new HeroDialogPart("W takim razie radź sobie sam.", null), new HeroDialogPart("No dobra, no to chodz Wrzodzie.", null) };

        HeroDialogPart[] heroDialogParts2 = { new HeroDialogPart("100 sztuk złota to za mało...", new NpcDialogPart("Niestety nie mam więcej. Jestem bardzo biedny.", heroDialogParts3)), new HeroDialogPart("Nie. Nie pomogę. Nie ma szans.", null) };

        HeroDialogPart[] heroDialogParts1 = { new HeroDialogPart("Tak, chętnie pomogę", new NpcDialogPart("Dziękuję #HERONAME#! W nagrodę otrzymasz ode mnie 100 bryłek rudy.", heroDialogParts2)), new HeroDialogPart("Nie. Radź sobie sam wrzodzie.", null) };

        NpcDialogPart npcDialogPart1 = new NpcDialogPart("Witaj " +
            "#HERONAME#!" +
            " Czy możesz mi pomóc dostać się do innego miasta?", heroDialogParts1);

        NonPlayerCharacter locationNpc1 = new NonPlayerCharacter("Wrzód", npcDialogPart1);

        NonPlayerCharacter locationNpc2 = new NonPlayerCharacter("Gomez", npcDialogPart2);


        NonPlayerCharacter[] locationNpcs = { locationNpc1, locationNpc2 };
        Location location = new Location("Stary obóz", locationNpcs);

        ShowLocation(location);

        NonPlayerCharacter? npc = location.InvokeNpcChoice();

        while (npc != null)
        {
            Console.Clear();
            DialogParser dialogParser = new DialogParser(hero);
            location.TalkTo(npc, dialogParser);
            Console.Clear();
            npc = location.InvokeNpcChoice();
        }

    }
}