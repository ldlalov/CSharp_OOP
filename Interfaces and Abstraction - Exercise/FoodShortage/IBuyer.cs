using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    internal interface IBuyer
    {
        string Name { get; }
        int Food { get; }
        public void BuyFood();
    }
}
