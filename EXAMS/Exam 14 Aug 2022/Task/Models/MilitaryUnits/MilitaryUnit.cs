using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel;
        public MilitaryUnit(double cost)
        {
            this.cost = cost;
            this.enduranceLevel = 1;
        }

        public double Cost => cost;

        public int EnduranceLevel => enduranceLevel;

        public void IncreaseEndurance()
        {
            if (enduranceLevel>20)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.EnduranceLevelExceeded));
            }
            enduranceLevel++;
        }
    }
}
