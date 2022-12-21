using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;
        public Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int Health
        {
            get { return health; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                health = value;
            }
        }

        public int Armour
        {
            get { return armour; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                armour = value;
            }
        }

        public IWeapon Weapon
        {
            get { return weapon; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }
                weapon = value;
            }
        }

        public bool IsAlive
        {
            get
            {
                if (Health > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public void AddWeapon(IWeapon weapon)
        {
            if (this.weapon == null)
            {
                this.weapon = weapon;
            }
        }

        public void TakeDamage(int points)
        {
            if (armour > 0)
            {
               armour -= points;
                if (armour <= 0)
                {
                    health -= Math.Abs(armour);
                    armour = 0;
                }
            }
            else
            {
                health -= points;
                if (health<=0)
                {
                    health = 0;
                }
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name}: {Name}");
            sb.AppendLine($"--Health: {Health}");
            sb.AppendLine($"--Armour: {Armour}");
            if (Weapon != null)
            {
                sb.Append($"--Weapon: {Weapon.Name}");
            }
            else
            {
                sb.Append($"--Weapon: Unarmed");
            }
            return sb.ToString().Trim();
        }
    }
}
