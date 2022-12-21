using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    internal class Coffee : HotBeverage
    {
        private const double CoffeeMililliters = 50;
        private const decimal CoffeePrice = 3.50m;
        public Coffee(string name, double caffeine) : base(name, CoffeePrice, CoffeeMililliters)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
