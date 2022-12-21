using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += 1.4;
        }
        //public override void isFull()
        //{
        //   FuelConsumption += 1.4;
        //}
        //public override void isEmpty()
        //{
        //    FuelConsumption = 0.3;
        //}

    }
}
