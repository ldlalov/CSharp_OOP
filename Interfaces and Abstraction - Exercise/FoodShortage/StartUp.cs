using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();
            int people = int.Parse(Console.ReadLine());
            for (int i = 0; i < people; i++)
            {
                string[] buyer = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (buyer.Length == 4)
                {
                    string name = buyer[0];
                    int age = int.Parse(buyer[1]);
                    string id = buyer[2];
                    string birthdate = buyer[3];
                    IBuyer citizen = new Citizen(name, age, id, birthdate);
                    buyers.Add(citizen);
                }
                if (buyer.Length == 3)
                {
                    string name = buyer[0];
                    int age = int.Parse(buyer[1]);
                    string group = buyer[2];
                    IBuyer rebel = new Rebel(name, age, group);
                    buyers.Add(rebel);
                }
            }
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                foreach (var buyer in buyers)
                {
                    if (buyer.Name == command)
                    {
                        buyer.BuyFood();
                    }
                }
            }
            Console.WriteLine(buyers.Sum(x => x.Food));
        }
    }
}
