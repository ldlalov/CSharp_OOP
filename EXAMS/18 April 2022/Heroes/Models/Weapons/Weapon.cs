using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;
        private int damage;

        protected Weapon(string name, int durability)
        {
            Name = name;
            Durability = durability;
        }
        public int Damage
        {
            get { return damage; }
            protected set { damage = value; }
        }
        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Weapon type cannot be null or empty.");
                }
                name = value;
            }
        }

        public int Durability
        {
            get { return durability; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Durability cannot be below 0.");
                }
                durability = value;
            }
        }
        public int DoDamage()
        {
            if (Durability>0)
            {
                Durability--;
                return damage;
            }
            return 0;
        }

    }
}
