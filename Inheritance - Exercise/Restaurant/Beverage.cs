using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    internal class Beverage : Product
    {
        public Beverage(string name, decimal price, double mililliters) : base(name, price)
        {
            Mililliters = mililliters;
        }
        public virtual double Mililliters { get; set; }
    }
}
