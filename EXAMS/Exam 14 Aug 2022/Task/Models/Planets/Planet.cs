using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private UnitRepository army;
        private WeaponRepository weapons;
        public Planet(string name, double budget)
        {
            this.name = name;
            this.budget = budget;
            this.army = new UnitRepository();
            this.weapons = new WeaponRepository();
        }
        public string Name
        {
            get { return name; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidPlanetName));
                }
                name = value;
            }
        }

        public double Budget
        {
            get { return budget; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidBudgetAmount));
                }
            }
        }

        public double MilitaryPower => 
            Math.Round(MilitaryPowerSums(),3);

        public IReadOnlyCollection<IMilitaryUnit> Army => army.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            army.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {name}");
            sb.AppendLine($"--Budget: {budget} billion QUID");
            sb.AppendLine($"--Forces: ");
            if (Army.Count == 0)
            {
                sb.AppendLine("No units");
            }
            else
            {
                var units = new Queue<string>();

                foreach (var item in Army)
                {
                    units.Enqueue(item.GetType().Name);
                }

                sb.AppendLine(string.Join(", ", units));
            }
            sb.Append($"--Combat equipment: ");

            if (Weapons.Count == 0)
            {
                sb.AppendLine("No weapons");
            }
            else
            {
                var equipment = new Queue<string>();

                foreach (var item in Weapons)
                {
                    equipment.Enqueue(item.GetType().Name);
                }

                sb.AppendLine(string.Join(", ", equipment));
            }
            sb.AppendLine($"--Military Power: {this.MilitaryPower}");

            return sb.ToString().Trim();
        }

        public void Profit(double amount)
        {
            budget += amount;
        }

        public void Spend(double amount)
        {
            if (budget < amount)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnsufficientBudget));
            }
            budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in Army)
            {
                unit.IncreaseEndurance();
            }
        }

        private double MilitaryPowerSums()
        {
            double result;
            result = army.Models.Sum(x => x.EnduranceLevel) + weapons.Models.Sum(x => x.DestructionLevel);
            if (army.Models.Any(x => x.GetType().Name == "AnonymousImpactUnit"))
            {
                result *= 1.3;
            }
            if (weapons.Models.Any(x => x.GetType().Name == "NuclearWeapon"))
            {
                result *= 1.45;
            }
            return result;
        }

    }
}
