using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    internal class Tea : HotBeverage
    {
        public Tea(string name, decimal price, double mililliters) : base(name, price, mililliters)
        {
        }
    }
}
