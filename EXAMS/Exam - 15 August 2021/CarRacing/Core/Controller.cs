using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        IMap map;
        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if (type != "SuperCar" && type != "TunedCar")
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidCarType));
            }
            ICar car;
            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            cars.Add(car);
            return String.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            if (cars.FindBy(carVIN) == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CarCannotBeFound));
            }
            if (type != "StreetRacer" && type != "ProfessionalRacer")
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidRacerType));
            }
            var car = cars.FindBy(carVIN);
            IRacer racer;
            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username, car);
            }
            else
            {
                racer = new StreetRacer(username, car);
            }
            racers.Add(racer);
            return String.Format(OutputMessages.SuccessfullyAddedRacer, racer.Username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            if (racers.FindBy(racerOneUsername) == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound,racerOneUsername));
            }
            if (racers.FindBy(racerTwoUsername) == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound,racerTwoUsername));
            }
            IRacer racer1 = racers.FindBy(racerOneUsername);
            IRacer racer2 = racers.FindBy(racerTwoUsername);
            return map.StartRace(racer1, racer2);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var racer in racers.Models.OrderByDescending(r => r.DrivingExperience).ThenBy(r => r.Username))
            {
                sb.AppendLine($"{racer.GetType().Name}: {racer.Username}");
                sb.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                sb.AppendLine($"--Car: {racer.Car}");
            }
            return sb.ToString().Trim();

        }
    }
}
