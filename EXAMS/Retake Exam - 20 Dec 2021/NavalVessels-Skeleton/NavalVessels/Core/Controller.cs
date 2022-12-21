using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core
{
    
    public class Controller : IController
    {
        private VesselRepository vessels;
        private ICollection<ICaptain> captains;
        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            if (captains.FirstOrDefault(c => c.FullName == selectedCaptainName) == null)
            {
                return String.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            if (vessels.FindByName(selectedVesselName) == null)
            {
                return String.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }
            if (vessels.FindByName(selectedVesselName).Captain != null)
            {
                return String.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }
            var captain = captains.FirstOrDefault(c => c.FullName == selectedCaptainName);
            var vessel = vessels.FindByName(selectedVesselName);
            vessel.Captain = captain;
            captain.AddVessel(vessel);
            return String.Format(OutputMessages.SuccessfullyAssignCaptain,selectedCaptainName,selectedVesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attacker = vessels.FindByName(attackingVesselName);
            var defender = vessels.FindByName(defendingVesselName);
            if (attacker == null )
            {
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            if (defender == null )
            {
                return String.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }
            if (attacker.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            if (defender.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }
            attacker.Attack(defender);
            attacker.Captain.IncreaseCombatExperience();
            defender.Captain.IncreaseCombatExperience();
            return String.Format(OutputMessages.SuccessfullyAttackVessel,defendingVesselName,attackingVesselName,defender.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            return captains.FirstOrDefault(c => c.FullName == captainFullName).Report();
        }

        public string HireCaptain(string fullName)
        {
            Captain captain = new Captain(fullName);
            if (captains.FirstOrDefault(c => c.FullName == fullName) != null)
            {
                return String.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }
            captains.Add(captain);
            return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vessels.Models.FirstOrDefault(v => v.Name == name) != null)
            {
                return String.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }
            if (vesselType != "Battleship" && vesselType != "Submarine")
            {
                return String.Format(OutputMessages.InvalidVesselType);
            }
            IVessel vessel;
            if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            vessels.Add(vessel);
            return String.Format(OutputMessages.SuccessfullyCreateVessel,vesselType,name,mainWeaponCaliber,speed);
        }

        public string ServiceVessel(string vesselName)
        {
            if (vessels.FindByName(vesselName) == null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }
            vessels.FindByName(vesselName).RepairVessel();
            return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            if (vessels.FindByName(vesselName) == null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }
            var vessel = vessels.FindByName(vesselName);
            if (vessel.GetType().Name == "Battleship")
            {
                Battleship battleship = (Battleship)vessels.FindByName(vesselName);
                battleship.ToggleSonarMode();
                return String .Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else 
            {
                Submarine submarine = (Submarine)vessels.FindByName(vesselName);
                submarine.ToggleSubmergeMode();
                return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }
        }

        public string VesselReport(string vesselName)
        {
            return vessels.FindByName(vesselName).ToString();
        }
    }
}
