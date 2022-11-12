using System;
namespace zadanie_01.common.models
{
    public class Hero
    {
        public Hero(string name, EHeroClass heroClass)
        {
            Name = name;
            HeroClass = heroClass;
        }

        public string Name { get; }
        public EHeroClass HeroClass { get; }

        public override string ToString() => $"({Name}, {HeroClass})";

    }
}

