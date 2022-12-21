﻿using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int drivingExperience = 30;
        private const string racingBehavior = "strict";
        public ProfessionalRacer(string username, ICar car) : base(username, racingBehavior, drivingExperience, car)
        {
        }
        public override void Race()
        {
            Car.Drive();
            DrivingExperience += 10;
        }
    }
}
