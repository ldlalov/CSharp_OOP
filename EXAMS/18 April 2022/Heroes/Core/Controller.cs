using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;
        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            if (heroes.FindByName(heroName) == default)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            if (weapons.FindByName(weaponName) == default)
            {
                throw new ArgumentException($"Weapon {weaponName} does not exist.");
            }
            if (heroes.FindByName(heroName).Weapon != default)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }
            IWeapon weapon = weapons.FindByName(weaponName);
            heroes.FindByName(heroName).AddWeapon(weapon);
            weapons.Remove(weapon);
            return String.Format($"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.");
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (heroes.FindByName(name) != default)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }
            if (type != "Knight" && type != "Barbarian")
            {
                throw new InvalidOperationException("Invalid hero type.");
            }
            if (type == "Knight")
            {
                IHero hero = new Knight(name, health, armour);
                heroes.Add(hero);
                return String.Format($"Successfully added Sir {name} to the collection.");
            }
            else
            {
                IHero hero = new Barbarian(name, health, armour);
                heroes.Add(hero);
                return String.Format($"Successfully added Barbarian {name} to the collection.");
            }
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.FindByName(name) != default)
            {
                throw new ArgumentException($"The weapon {name} already exists.");
            }
            if (type != "Mace" && type != "Claymore")
            {
                throw new ArgumentException("Invalid weapon type.");
            }
            if (type == "Mace")
            {
                IWeapon weapon = new Mace(name, durability);
                weapons.Add(weapon);
                return String.Format($"A mace {name} is added to the collection.");
            }
            else
            {
                IWeapon weapon = new Claymore(name, durability);
                weapons.Add(weapon);
                return String.Format($"A claymore {name} is added to the collection.");
            }
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var hero in heroes.Models.OrderBy(h => h.GetType().Name).ThenByDescending(h => h.Health).ThenBy(h => h.Name))
            {
                sb.AppendLine(hero.ToString());
            }
            return sb.ToString();
        }

        public string StartBattle()
        {
            Map map = new Map();
            var fighters = heroes.Models.Where(h => h.IsAlive && h.Weapon != null);
            return map.Fight(heroes.Models.Where(x => x.IsAlive && x.Weapon != null).ToList());
        }
    }
}
