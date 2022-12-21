using System;
using System.Collections.Generic;

namespace Polymorphism
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());
            while(heroes.Count < n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                BaseHero hero = null;
                switch (type)
                {
                    case "Druid":
                        hero = new Druid(name, 0);
                        break;
                    case "Paladin":
                        hero = new Paladin(name, 0);
                        break;
                    case "Rogue":
                        hero = new Rogue(name, 0);
                        break;
                    case "Warrior":
                        hero = new Warrior(name, 0);
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        continue;
                }
                heroes.Add(hero);
            }
            int bossPower = int.Parse(Console.ReadLine());
            int heroesPower = 0;
            if (heroes.Count > 0)
            {
                foreach (var hero in heroes)
                {
                    heroesPower += hero.Power;
                    Console.WriteLine(hero.CastAbility());
                }
            }
            if (heroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
