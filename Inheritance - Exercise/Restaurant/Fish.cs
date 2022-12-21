using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Text;

namespace Restaurant
{
    internal class Fish : MainDish
    {
        private const double FishGrams = 22;
        public Fish(string name, decimal price) : base(name, price, FishGrams )
        {
        }
    }
}
