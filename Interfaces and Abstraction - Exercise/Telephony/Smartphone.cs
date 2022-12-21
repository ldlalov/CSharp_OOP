using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public  class Smartphone : ICall, IBrowse
    {
        public Smartphone()
        {
        }

        public void Call(string number)
        {
            if (int.TryParse(number, out int r) == true)
            {
                Console.WriteLine($"Calling... {number}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }
        public void Browse(string url)
        {
            foreach (char char1 in url)
            {
                if (char.IsDigit(char1))
                {
                    Console.WriteLine("Invalid URL!");
                    return;
                }
            }
            Console.WriteLine($"Browsing: {url}!");
        }
    }
}
