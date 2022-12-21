using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;
        public Captain(string fullName)
        {
            FullName = fullName;
            Vessels = new List<IVessel>();
        }
        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                fullName = value;
            }
        }

        public int CombatExperience
        {
            get { return combatExperience; }
            private set
            {
                combatExperience = value;
            }
        }

        public ICollection<IVessel> Vessels { get;private set; }

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new ArgumentNullException(ExceptionMessages.InvalidVesselForCaptain);
            }
            Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            combatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{fullName} has {CombatExperience} combat experience and commands {Vessels.Count} vessels.");
            if (Vessels.Count > 0)
            {
                foreach (var vessel in Vessels)
                {
                    sb.AppendLine(vessel.ToString());
                }
            }
            return sb.ToString().Trim();
        }
    }
}
