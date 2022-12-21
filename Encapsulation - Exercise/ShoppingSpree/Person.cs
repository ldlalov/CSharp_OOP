using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products = new List<Product>();
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
        }

        public string Name 
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                else
                {
                    name = value;
                }
            }
        }
        public decimal Money 
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                else
                {
                    money = value;
                }
            }
        }
        public IReadOnlyCollection<Product> Products => products;

        public void Buy(Product product)
        {

            if (product.Cost<= money)
            {
                products.Add(product);
                Console.WriteLine($"{Name} bought {product.Name}");
                money -= product.Cost;
            }
            else
            {
                throw new ArgumentException($"{Name} can't afford {product.Name}");
            }
        }
        public void ShowBag()
        {
            if (Products.Count>0)
            {
                Console.WriteLine($"{string.Join(", ",products.Select(x => x.Name))}");
            }
            else
            {
                Console.WriteLine("Nothing bought");
            }
        }
    }
}
