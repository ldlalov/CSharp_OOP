using System;
namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string animalType; 
            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                string[] details = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = details[0];
                int age = int.Parse(details[1]);
                string gender = "";
                if (details.Length == 3)
                {
                    gender = details[2];
                }
                switch (animalType)
                {
                    case "Dog":
                        Dog dog = new Dog(name, age, gender);
                        Console.WriteLine(dog);
                        break;
                    case "Cat":
                        Cat cat = new Cat(name, age, gender);
                        Console.WriteLine(cat);
                        break;
                    case "Frog":
                        Frog frog = new Frog(name, age, gender);
                        Console.WriteLine(frog);
                        break;
                    case "Kitten":
                        Kitten kitten = new Kitten(name, age);
                        Console.WriteLine(kitten);
                        break;
                    case "Tomcat":
                        Tomcat tomcat = new Tomcat(name, age);
                        Console.WriteLine(tomcat);
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;

                }
            }
        }
    }
}
