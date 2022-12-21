using System;
using System.Collections.Generic;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] theCar = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string[] theTruck = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] theBus = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Vehicle car = new Car(double.Parse(theCar[1]), double.Parse(theCar[2]), double.Parse(theCar[3]));
            Vehicle truck = new Truck(double.Parse(theTruck[1]), double.Parse(theTruck[2]), double.Parse(theTruck[3]));
            Vehicle bus = new Bus(double.Parse(theBus[1]), double.Parse(theBus[2]), double.Parse(theBus[3]));
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] cmd = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                    switch (cmd[0])
                    {
                        case "Drive":
                            if (cmd[1] == "Car")
                            {
                                Console.WriteLine(car.Drive(double.Parse(cmd[2])));
                            }
                            else if (cmd[1] == "Truck")
                            {
                                Console.WriteLine(truck.Drive(double.Parse(cmd[2])));
                            }
                            else if (cmd[1] == "Bus")
                            {
                                Console.WriteLine(bus.Drive(double.Parse(cmd[2])));
                            }
                            break;
                        case "DriveEmpty":
                            Console.WriteLine(bus.DriveEmpty(double.Parse(cmd[2])));
                            break;
                        case "Refuel":
                            if (cmd[1] == "Car")
                            {
                                car.Refuel(double.Parse(cmd[2]));
                            }
                            else if (cmd[1] == "Truck")
                            {
                                truck.Refuel(double.Parse(cmd[2]));

                            }
                            else if (cmd[1] == "Bus")
                            {
                                bus.Refuel(double.Parse(cmd[2]));
                            }
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
