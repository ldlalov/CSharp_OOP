using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private List<string> targets;
        private double mainWeaponCaliber;

        public Vessel(string name, double mainWeaponCaliber,double speed,double armourThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armourThickness;
            targets = new List<string>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(String.Format(ExceptionMessages.InvalidVesselName));
                }
                name = value;
            }
        }

        public ICaptain Captain 
        { get { return captain; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(String.Format(ExceptionMessages.InvalidCaptainToVessel));
                }
                captain = value;
            }
                }
        public double ArmorThickness { get ; set ; }

        public virtual double MainWeaponCaliber { get { return mainWeaponCaliber; }
            protected set
            {
                mainWeaponCaliber = value;
            }
        }

        public double Speed { get;protected set; }

        public ICollection<string> Targets => targets;


        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.InvalidTarget));
            }
                target.ArmorThickness -= MainWeaponCaliber;
            if (target.ArmorThickness<0)
            {
                target.ArmorThickness = 0;
            }
                targets.Add(target.Name);

        }

        public virtual void RepairVessel()
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {Speed} knots");
            sb.Append($" *Targets: ");
            if (Targets.Count > 0)
            {
                sb.AppendLine($"{string.Join(", ", Targets)}");
            }
            else
            {
                sb.AppendLine("None");
            }
            return sb.ToString().Trim();
        }
    }
}
