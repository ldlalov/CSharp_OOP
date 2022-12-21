using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IId> citizens = new List<IId>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] visitor = command.Split();

                if (visitor.Length == 3)
                {
                    string name = visitor[0];
                    int age = int.Parse(visitor[1]);
                    string id = visitor[2];
                    IId human = new Citizen(name, age, id);
                    citizens.Add(human);
                }
                if (visitor.Length == 2)
                {
                    string model = visitor[0];
                    string id = visitor[1];
                    IId robot = new Robot(model, id);
                    citizens.Add(robot);
                }
            }
            string fakeId = Console.ReadLine();
            foreach (var citizen in citizens)
            {
                if (citizen.Id.Substring(citizen.Id.Length - fakeId.Length) == fakeId)
                {
                    Console.WriteLine(citizen.Id);
                }
            }
        }
    }
}
