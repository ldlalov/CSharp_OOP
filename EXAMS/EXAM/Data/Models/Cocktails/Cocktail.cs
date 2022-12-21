using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;
        public Cocktail(string cocktailName, string size, double price)
        {
            Name = cocktailName;
            Size = size;
            Price = price;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.NameNullOrWhitespace));
                }
                name = value;
            }
        }

        public string Size
        {
            get
            { return size; }
              private set
            {
                size = value;
            }
        
        }

        public double Price 
        { 
            get
            {
                return price;
            }
               private set
            {
                if (size == "Large")
                {
                    price = value;
                }
                else if (size == "Middle")
                {
                    price = value * 2/3;
                }
                else
                {
                    price = value / 3;
                }
            }
                
        }
        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:f2} lv";
        }
    }
}
