using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private Dictionary<string, double> toppings = new Dictionary<string, double>()
        {
            { "Meat",1.2 },
            { "Veggies",0.8 },
            { "Cheese",1.1 },
            { "Sauce",0.9 },

        };

        private string name;
        private double weight;
        public Topping(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (toppings.ContainsKey(char.ToUpper(value[0]) + value.Substring(1).ToLower()))
                {
                    name = char.ToUpper(value[0]) + value.Substring(1).ToLower();
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
            }
        }
        public double Weight
        {
            get { return weight; }
            set
            {
                if (value > 0 && value <= 50)
                {
                    weight = value;
                }
                else
                {
                    throw new ArgumentException($"{Name} weight should be in the range [1..50].");
                }
            }

        }
        public double CalculateCalories()
        {
            double sum = 2 * weight * toppings[name];
            return sum;
        }

    }
}
