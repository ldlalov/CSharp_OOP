using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double defaultArmourThickness = 300;

        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, defaultArmourThickness)
        {
        }

        public bool SonarMode { get; private set; }


        public void ToggleSonarMode()
        {
            if (SonarMode)
            {
                MainWeaponCaliber -= 40;
                Speed += 5;
                SonarMode = false;
            }
            else
            {
                MainWeaponCaliber += 40;
                Speed -= 5;
                SonarMode = true;
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
            if (SonarMode)
            {
                onOff = "ON";
            }
            else
            {
                onOff = "OFF";
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Sonar mode: {onOff}");
            return sb.ToString().Trim();
        }

    }
}
