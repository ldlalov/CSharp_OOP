using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.Planets;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    internal class Controller : IController
    {
        private PlanetRepository planets;
        public Controller()
        {
            planets = new PlanetRepository();
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            if(planets.FindByName(planetName)==null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            MilitaryUnit unit;
            if (unitTypeName == "AnonymousImpactUnit")
            {
                unit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == "StormTroopers")
            {
                unit = new StormTroopers();
            }
            else
            {
                throw new InvalidOperationException($"{unitTypeName} still not available!");
            }
            if (true)
            {

            }

            return null;
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            throw new NotImplementedException();
        }

        public string CreatePlanet(string name, double budget)
        {
            Planet planet = new Planet(name, budget);
            if (planets.FindByName(name) != null)
            {
                return String.Format(OutputMessages.ExistingPlanet,name);
            }
            planets.AddItem(planet);
            return String.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            throw new NotImplementedException();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            throw new NotImplementedException();
        }

        public string SpecializeForces(string planetName)
        {
            throw new NotImplementedException();
        }
    }
}
