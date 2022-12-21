using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IId> citizens = new List<IId>();
            Queue<IBirthable> goodCreatures = new Queue<IBirthable>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] visitor = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);

                if (visitor.Length == 5)
                {
                    string name = visitor[1];
                    int age = int.Parse(visitor[2]);
                    string id = visitor[3];
                    string birthdate = visitor[4];
                    IId human = new Citizen(name, age, id,birthdate);
                    IBirthable human1 = new Citizen(name, age, id,birthdate);
                    goodCreatures.Enqueue(human1);
                    citizens.Add(human);
                }
                if (visitor.Length == 3)
                {
                    if (visitor[0] == "Robot")
                    {
                    string model = visitor[1];
                    string id = visitor[2];
                    IId robot = new Robot(model, id);
                    citizens.Add(robot);
                    }
                    if (visitor[0] == "Pet")
                    {
                        string name = visitor[1];
                        string birthdate = visitor[2];
                        IBirthable pet = new Pet(name, birthdate);
                        goodCreatures.Enqueue(pet);
                    }
                }
            }
            string fakeId = Console.ReadLine();
            while (goodCreatures.Count>0)
            {
                IBirthable temp = goodCreatures.Dequeue();
                if (temp.Birthdate.Substring(temp.Birthdate.Length - fakeId.Length) == fakeId)
                {
                    Console.WriteLine(temp.Birthdate);
                }
            }
        }
    }
}
