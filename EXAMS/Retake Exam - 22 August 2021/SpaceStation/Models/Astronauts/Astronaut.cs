using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private Backpack backpack;
        public Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            backpack = new Backpack();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidAstronautName));
                }
                name = value;
            }
        }

        public double Oxygen
        {
            get { return oxygen; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidOxygen));
                }
                oxygen = value;
            }
        }

        public bool CanBreath { get; private set; }

        public IBag Bag => backpack;

        public virtual void Breath()
        {
            Oxygen -=10;
            if (Oxygen<0)
            {
                Oxygen = 0;
            }
        }
    }
}
