using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings = new List<Topping>();

        public Pizza(string name)
        {
            Name = name;
        }
        public IReadOnlyCollection<Topping> Toppings => toppings;
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length>15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                else
                {
                  name = value;
                }
            }
        }
        public Dough Dough { get; set; }
        public void AddTopping(Topping topping)
        {
            if (toppings.Count<=10)
            {
                toppings.Add(topping);
            }
            else
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
        }
        public double PizzaCalories()
        {
            double sum = 0;
            sum += Dough.CalculateCalories();
            if (toppings.Count>0)
            {
                sum  += toppings.Sum(x => x.CalculateCalories());
            }
            return sum;
        }
        public override string ToString()
        {
            StringBuilder pizza = new StringBuilder();
            pizza.AppendLine($"{name} - {PizzaCalories():f2} Calories.");
            return pizza.ToString();
        }
    }
}
