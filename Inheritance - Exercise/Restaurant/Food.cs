﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    internal class Food : Product
    {
        public Food(string name, decimal price, double grams) : base(name, price)
        {
            Grams = grams;
        }
        public virtual double Grams { get; set; }
    }
}
