using Formula1.Core.Contracts;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Formula1.Core
{
    internal class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;
        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            if (pilotRepository.FindByName(pilotName) == null || pilotRepository.FindByName(pilotName).Car != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage,pilotName));
            }
            if (carRepository.FindByName(carModel) == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }
            var car = carRepository.FindByName(carModel);
            pilotRepository.FindByName(pilotName).AddCar(car);
            carRepository.Remove(car);
            return String.Format(OutputMessages.SuccessfullyPilotToCar, pilotName,car.GetType().Name,carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            if (raceRepository.FindByName(raceName) == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if (pilotRepository.FindByName(pilotFullName) == null || pilotRepository.FindByName(pilotFullName).CanRace == false || raceRepository.FindByName(raceName).Pilots.FirstOrDefault(x => x.FullName == pilotFullName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage,pilotFullName));
            }
            raceRepository.FindByName(raceName).AddPilot(pilotRepository.FindByName(pilotFullName));
            return String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (carRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage,model));
            }
            if (type != "Ferrari" && type != "Williams")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }
            IFormulaOneCar car;
            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            carRepository.Add(car);
            return String.Format(OutputMessages.SuccessfullyCreateCar, type,model);
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }
            Pilot pilot = new Pilot(fullName);
            pilotRepository.Add(pilot);
            return String.Format(OutputMessages.SuccessfullyCreatePilot,fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage,raceName));
            }
            Race race = new Race(raceName, numberOfLaps);
            raceRepository.Add(race);
            return String.Format(OutputMessages.SuccessfullyCreateRace,raceName);
        }

        public string PilotReport()
        {
            StringBuilder pilotReport = new StringBuilder();
            foreach (var pilot in pilotRepository.Models.OrderByDescending(x => x.NumberOfWins))
            {
                pilotReport.AppendLine(pilot.ToString());
            }
            return pilotReport.ToString().Trim();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var race in raceRepository.Models.Where(race => race.TookPlace))
            {
                sb.AppendLine($"The {race.RaceName} race has:");
                sb.AppendLine($"Participants: {race.Pilots.Count}");
                sb.AppendLine($"Number of laps: {race.NumberOfLaps}");
                sb.AppendLine($"Took place: Yes");
            }
            return sb.ToString().Trim();
        }

        public string StartRace(string raceName)
        {
            if (raceRepository.FindByName(raceName) == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage,raceName));
            }
            if (raceRepository.FindByName(raceName).Pilots.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            if (raceRepository.FindByName(raceName).TookPlace == true)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage,raceName));
            }
            var race = raceRepository.FindByName(raceName);
            StringBuilder sb = new StringBuilder();
            int count = 0;
            foreach (var pilot in race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).Take(3))
            {
                if (count == 0)
                {
                sb.AppendLine($"Pilot {pilot.FullName} wins the {raceName} race.");
                    pilot.WinRace();
               }
                else if (count == 1)
                {
                    sb.AppendLine($"Pilot {pilot.FullName} is second in the {raceName} race.");
                }
                else
                {
                    sb.Append($"Pilot {pilot.FullName} is third in the {raceName} race.");
                }
                count++;
            }
            race.TookPlace = true;
            return sb.ToString().Trim();
        }
    }
}
