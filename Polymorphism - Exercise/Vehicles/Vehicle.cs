using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            } 
        }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }
        public virtual string Drive(double kilometers)
        {
            if ((FuelQuantity -( FuelConsumption * kilometers)) <= 0)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }
            FuelQuantity -= FuelConsumption * kilometers;
            return $"{GetType().Name} travelled {kilometers} km";
        }
        public virtual string DriveEmpty(double kilometers)
        {
            if ((FuelQuantity -( (FuelConsumption - 1.4) * kilometers)) <= 0)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }
            FuelQuantity -= (FuelConsumption - 1.4) * kilometers;
            return $"{GetType().Name} travelled {kilometers} km";
        }
        public virtual void Refuel(double liters)
        {
            if(FuelQuantity + liters > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (this.GetType().Name == "Truck")
            {
                liters *= 0.95;
            }
            FuelQuantity += liters;
        }
    }
}