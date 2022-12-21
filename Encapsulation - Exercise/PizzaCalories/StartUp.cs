using System;
using System.Collections.Generic;
using System.Linq;
namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] pizzaDetails = Console.ReadLine().Split(" ");
            try
            {
                Pizza pizza = new Pizza(pizzaDetails[1]);
                double doughGrams = 0;
                string[] doughDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string floor = doughDetails[1];
                    string bakingTechnique = doughDetails[2];
                    doughGrams = double.Parse(doughDetails[3]);

                    try
                    {
                        Dough dough = new Dough(floor, bakingTechnique, doughGrams);
                        pizza.Dough = dough;
                    }
                    catch (ArgumentException ex)
                    {

                        Console.WriteLine(ex.Message);
                        return;
                    }

                double toppingGrams = 0;
                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] toppingDetails = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        string toppingType = toppingDetails[1];
                        toppingGrams = double.Parse(toppingDetails[2]);
                        try
                        {
                            Topping topping = new Topping(toppingType, toppingGrams);
                            pizza.AddTopping(topping);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                            return;
                        }
                    }
                Console.WriteLine(pizza);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
