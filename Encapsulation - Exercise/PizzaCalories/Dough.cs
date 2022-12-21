using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string name;
        private string bakingTechnique;
        private double weight;
        private Dictionary<string,double> doughs = new Dictionary<string, double>()
        {
            { "White",1.5 },
            { "Wholegrain",1.0 },
        };
        private Dictionary<string,double> bakingTechniques = new Dictionary<string, double>()
        {
            { "Crispy",0.9 },
            { "Chewy",1.1 },
            { "Homemade",1.0 },
        };
        public Dough(string name, string bakingTechnique, double weight)
        {
            Name = name;
            Weight = weight;
            BakingTechnique = bakingTechnique;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (doughs.ContainsKey(char.ToUpper(value[0]) + value.Substring(1).ToLower()))
                {
                    name = char.ToUpper(value[0]) + value.Substring(1).ToLower();
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        public string BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                if (bakingTechniques.ContainsKey(char.ToUpper(value[0]) + value.Substring(1).ToLower()))
                {
                    bakingTechnique = char.ToUpper(value[0]) + value.Substring(1).ToLower();
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        public double Weight
        {
            get { return weight; }
            set
            {
                if (value>0 && value <=200)
                {
                    weight = value;
                }
                else
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
            }
        }
        public double CalculateCalories()
        {
            double sum = 2 * weight * doughs[name] * bakingTechniques[bakingTechnique];
            return sum;
        }
    }
}
