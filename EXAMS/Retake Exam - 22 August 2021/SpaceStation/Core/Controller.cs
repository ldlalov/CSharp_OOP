using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    internal class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private int exploredPlanetsCount;
        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if (type != "Biologist" && type != "Geodesist" && type != "Meteorologist")
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidAstronautType));
            }
            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else
            {
                astronaut = new Meteorologist(astronautName);
            }
            astronauts.Add(astronaut);
            return String.Format(OutputMessages.AstronautAdded,type,astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            Planet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            planets.Add(planet);
            return String.Format(OutputMessages.PlanetAdded,planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            if (astronauts.Models.FirstOrDefault(a => a.Oxygen > 60) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAstronautCount));
            }
            Mission mission = new Mission();
            mission.Explore(planets.FindByName(planetName), astronauts.Models.Where(a => a.Oxygen > 60).ToList());
            int dead = astronauts.Models.Count(x => x.Oxygen <= 0);
            exploredPlanetsCount++;
            return String.Format(OutputMessages.PlanetExplored, planetName, dead);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanetsCount} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (var astronaut in astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                sb.Append("Bag items: ");
                if (astronaut.Bag.Items.Count == 0)
                {
                    sb.AppendLine("none");
                }
                else
                {
                    sb.AppendLine($"{string.Join(", ", astronaut.Bag.Items)}");
                }

            }
            return sb.ToString().Trim();
        }

        public string RetireAstronaut(string astronautName)
        {
            if (astronauts.FindByName(astronautName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }
            astronauts.Remove(astronauts.FindByName(astronautName));
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
