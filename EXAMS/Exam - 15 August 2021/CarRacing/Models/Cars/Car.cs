using CarRacing.Models.Cars.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumptionPerRace;
        public Car(string make, string model, string vin, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            Make = make;
            Model = model;
            VIN = vin;
            HorsePower = horsePower;
            FuelAvailable = fuelAvailable;
            FuelConsumptionPerRace = fuelConsumptionPerRace;
        }

        public string Make
        {
            get { return make; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCarMake));
                }
                make = value;
            }
        }

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCarModel));
                }
                model = value;
            }
        }

        public string VIN
        {
            get { return vin; }
            private set
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCarVIN));
                }
                vin = value;
            }
        }

        public int HorsePower
        {
            get { return horsePower; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCarHorsePower));
                }
                horsePower = value;
            }
        }

        public double FuelAvailable
        {
            get { return fuelAvailable; }
            private set
            {
                if (value <0)
                {
                    value = 0;
                }
                fuelAvailable = value;
            }
        }

        public double FuelConsumptionPerRace
        {
            get { return fuelConsumptionPerRace; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCarFuelConsumption));
                }
                fuelConsumptionPerRace = value;
            }
        }

        public void Drive()
        {
            FuelAvailable -= FuelConsumptionPerRace;
            if (this.GetType().Name == "TunedCar")
            {
                HorsePower -= (int)Math.Round(HorsePower * 0.03);
            }
        }
        public override string ToString()
        {
            return $"{Make} {Model} ({VIN})";
        }
    }
}
