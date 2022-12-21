using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel,ISubmarine
    {
        private const double defaultArmourThickness = 200;

        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, defaultArmourThickness)
        {
        }

        public bool SubmergeMode { get;private set; }
        public void ToggleSubmergeMode()
        {
            if (SubmergeMode)
            {
                MainWeaponCaliber -= 40;
                Speed += 4;
                SubmergeMode = false;
            }
            else 
            {
                MainWeaponCaliber += 40;
                Speed -= 4;
                SubmergeMode = true;
            }
        }
        public override void RepairVessel()
        {
            if (ArmorThickness < defaultArmourThickness)
            {
                ArmorThickness = defaultArmourThickness;
            }
        }
        public override string ToString()
        {
            string onOff;
            if (SubmergeMode)
            {
                onOff = "ON";
            }
            else
            {
                onOff = "OFF";
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Submerge mode: {onOff}");
            return sb.ToString().Trim();
        }

    }
}
