using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> costumers = new List<Person>();
            string[] people = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);
            foreach (var personDetails in people)
            {
                string[] strings = personDetails.Split("=",StringSplitOptions.RemoveEmptyEntries);
                string name = strings[0];
                decimal money = decimal.Parse(strings[1]);
                try
                {
                    Person person = new Person(name, money);
                    costumers.Add(person);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }

            }
            List<Product> productList = new List<Product>();
            string[] products = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);
            foreach (var productDetails in products)
            {
                string[] strings = productDetails.Split("=",StringSplitOptions.RemoveEmptyEntries);
                string name = strings[0];
                decimal cost = decimal.Parse(strings[1]);
                try
                {
                    Product product = new Product(name, cost);
                    productList.Add(product);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }

            }
            string purchase;
            while ((purchase = Console.ReadLine()) != "END")
            {
                string[] costumersProduct = purchase.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person costumer = costumers.FirstOrDefault(x => x.Name == costumersProduct[0]);
                Product product = productList.FirstOrDefault(p => p.Name == costumersProduct[1]);
                try
                {
                costumer.Buy(product);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            foreach (var costumer in costumers)
            {
                Console.Write($"{costumer.Name} - ");
                costumer.ShowBag();
            }
        }
    }
}
