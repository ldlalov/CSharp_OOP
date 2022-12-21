using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models.Contracts
{
    public class Pilot : IPilot
    {
        private string fullName;
        private int numberOfWins;
        private IFormulaOneCar car;
        public Pilot(string fullName)
        {
            FullName = fullName;
        }

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length<5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }
                fullName = value;
            }
        }


        public IFormulaOneCar Car
        {
            get { return car; }
            private set {
                if (car == null)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCarForPilot));
                }
                CanRace = true;
                car = value; 
            }
        }

        public int NumberOfWins
        {
            get { return numberOfWins; }
            private set
            {
                numberOfWins = value;
            }
        }

        public bool CanRace { get; private set; }

        public void AddCar(IFormulaOneCar car)
        {
            this.car = car;
            CanRace = true;
        }

        public void WinRace()
        {
            numberOfWins++;
        }
        public override string ToString()
        {
            return $"Pilot {FullName} has {NumberOfWins} wins.";
        }
    }
}
