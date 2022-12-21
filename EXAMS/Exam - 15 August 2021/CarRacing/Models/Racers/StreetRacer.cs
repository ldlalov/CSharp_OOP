using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    internal class StreetRacer : Racer
    {
        private const int drivingExperience = 10;
        private const string racingBehavior = "aggressive";
        public StreetRacer(string username, ICar car) : base(username, racingBehavior, drivingExperience, car)
        {
        }
        public override void Race()
        {
            Car.Drive();
            DrivingExperience += 5;
        }

    }
}
