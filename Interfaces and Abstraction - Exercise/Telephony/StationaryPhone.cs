using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    internal class StationaryPhone : ICall
    {
        public StationaryPhone()
        {

        }
        public void Call(string number)
        {
            if (int.TryParse(number,out int r) == true)
            {
                Console.WriteLine($"Dialing... {number}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }
    }
}
