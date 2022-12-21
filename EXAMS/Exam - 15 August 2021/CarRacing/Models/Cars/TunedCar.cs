using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    internal class TunedCar : Car
    {
        private const double fuelAvailable = 65;
        private const double fuelConsumptionPerRace = 7.5;

        public TunedCar(string make, string model, string vin, int horsePower) : base(make, model, vin, horsePower, fuelAvailable, fuelConsumptionPerRace)
        {
        }
    }
}
