using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private double price;
        private int destructionLevel;
        public Weapon(int destructionLevel, double price)
        {
            DestructionLevel = destructionLevel;
            this.price = price;

        }

        public double Price => price;

        public int DestructionLevel
        {
            get => destructionLevel;
            set
            {
                if (value<=0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.TooLowDestructionLevel));
                }
                else if (value>10)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.TooHighDestructionLevel));
                }
                destructionLevel = value;
            }
        }
    }
}
