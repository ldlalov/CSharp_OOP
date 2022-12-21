using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    internal class Animal
    {
        private int age = 0;
        
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;

        }
        public string Name { get; set; }
        public int Age
        {
            get { return age; }
            set
            {
                if (value<0)
                {
                    throw new Exception("Invalid input!");
                }
            } }
        public string Gender { get; set; }
        public virtual string ProduceSound()
        {
            return null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name}");
            sb.AppendLine($"{Name} {Age} {Gender}");
            sb.Append($"{ProduceSound()}");
            return sb.ToString();
        }
    }
}
