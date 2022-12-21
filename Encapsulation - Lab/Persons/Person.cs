using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age = 0;
        private decimal salary = 0;
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value.Length<3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                else
                {
                    firstName = value;
                }
            } 
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                else
                {
                    lastName = value;
                }
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                else
                {
                   age = value;
                }
            }
        }
        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (value<460)
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }
                else
                {
                    salary = value;
                }
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (Age < 30)
            {
                Salary += Salary * (percentage / 200);
            }
            else
            {
                Salary += Salary * (percentage/100);
            }
        }


        public override string ToString()
        {
            //first task
            //return $"{FirstName} {LastName} is {Age} years old.";
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }
    }
}
