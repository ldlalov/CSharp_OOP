using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private int age = 0;
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public virtual int Age
        {
            get { return age; } set
            {
                if (value<0)
                {
                    age = 0;
                }
                else
                {
                    age = value;
                }
            } 
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {Name}, Age: {Age}");
            return sb.ToString();
        }

    }
}
