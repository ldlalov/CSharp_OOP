using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //first task
            //var lines = int.Parse(Console.ReadLine());
            //var persons = new List<Person>();
            //for (int i = 0; i < lines; i++)
            //{
            //    var cmdArgs = Console.ReadLine().Split();
            //    var person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]));
            //    persons.Add(person);
            //}

            //persons.OrderBy(p => p.FirstName)
            //       .ThenBy(p => p.Age)
            //       .ToList()
            //       .ForEach(p => Console.WriteLine(p.ToString()));

            //second and third task 
            //var lines = int.Parse(Console.ReadLine());
            //var persons = new List<Person>();
            //Team team = new Team("SoftUni");

            //for (int i = 0; i < lines; i++)
            //{
            //    var cmdArgs = Console.ReadLine().Split();
            //    try
            //    {
            //        var person = new Person(cmdArgs[0],
            //                                cmdArgs[1],
            //                                int.Parse(cmdArgs[2]),
            //                                decimal.Parse(cmdArgs[3]));
            //        persons.Add(person);

            //    }
            //    catch (System.ArgumentException e)
            //    {
            //        Console.WriteLine(e.ToString());
            //    }

            //}
            //var parcentage = decimal.Parse(Console.ReadLine());
            //persons.ForEach(p => p.IncreaseSalary(parcentage));
            //persons.ForEach(p => Console.WriteLine(p.ToString()));

            //fourth task
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            Team team = new Team("SoftUni");

            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();
                try
                {
                    var person = new Person(cmdArgs[0],
                                            cmdArgs[1],
                                            int.Parse(cmdArgs[2]),
                                            decimal.Parse(cmdArgs[3]));
                    persons.Add(person);

                }
                catch (System.ArgumentException e)
                {
                    Console.WriteLine(e.ToString());
                }

            }
            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }
            Console.WriteLine(team);

        }
    }
}
