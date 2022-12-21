using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            HeroRepository knights = new HeroRepository();
            HeroRepository barbarians = new HeroRepository();
            foreach (var hero in players)
            {
                if (hero.GetType().Name == "Knight")
                {
                    knights.Add (hero);
                }
                else if (hero.GetType().Name == "Barbarian")
                {
                    barbarians.Add(hero);
                }
            }
            int deadKnights = 0;
            int deadBarbarians = 0;
            while (knights.Models.Any(x => x.IsAlive)
                && barbarians.Models.Any(x => x.IsAlive))
            {
                foreach (var knight in knights.Models)
                {
                    if (knight.IsAlive) 
                    {
                        foreach (var barbarian in barbarians.Models.Where(b => b.IsAlive))
                        {
                            int damage = knight.Weapon.DoDamage();
                                barbarian.TakeDamage(damage);
                                if (!barbarian.IsAlive)
                                {
                                    deadBarbarians++;
                                }
                            
                        }
                    }
                }
                foreach (var barbarian in barbarians.Models)
                {
                    if (barbarian.IsAlive)
                    {
                        foreach (var knight in knights.Models.Where(k => k.IsAlive))
                        {
                            int damage = barbarian.Weapon.DoDamage();
                            knight.TakeDamage(damage);
                            if (!knight.IsAlive)
                            {
                                deadKnights++;
                            }

                        }
                    }
                }
            }
            if (knights.Models.Any(x => x.IsAlive))
            {
                return String.Format($"The knights took {deadKnights} casualties but won the battle.");
            }
            else
            {
                return String.Format($"The barbarians took {deadBarbarians} casualties but won the battle.");

            }
        }
    }
}
