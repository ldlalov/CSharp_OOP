using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    internal class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return String.Format(OutputMessages.RaceCannotBeCompleted);
            }
            if (!racerOne.IsAvailable())
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable,racerTwo.Username,racerOne.Username);
            }
            if (!racerTwo.IsAvailable())
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable,racerOne.Username,racerTwo.Username);
            }
            double chanceOfWinning1 = racerOne.Car.HorsePower * racerOne.DrivingExperience * CalculateBehavier(racerOne.RacingBehavior);
            double chanceOfWinning2 = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * CalculateBehavier(racerTwo.RacingBehavior);
            racerOne.Race();
            racerTwo.Race();
            if (chanceOfWinning1>chanceOfWinning2)
            {
                return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);

            }
            else
            {
                return String.Format(OutputMessages.RacerWinsRace, racerTwo.Username, racerOne.Username, racerTwo.Username);
            }
        }


        public double CalculateBehavier(string racingBehavior)
        {
            if (racingBehavior == "strict")
            {
                return 1.2;
            }
            else
            {
                return 1.1;
            }
        }
    }
}
