using System;

namespace Telephony
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            StationaryPhone stationary = new StationaryPhone();
            Smartphone smartphone = new Smartphone();
            string[] phones = Console.ReadLine().Split();
            foreach (var phone in phones)
            {
                if (phone.Length == 7)
                {
                stationary.Call(phone);
                }
                if (phone.Length == 10)
                {
                    smartphone.Call(phone);
                }

            }
            string[] urls = Console.ReadLine().Split();
            foreach (var url in urls)
            {
                smartphone.Browse(url);
            }
        }
    }
}
