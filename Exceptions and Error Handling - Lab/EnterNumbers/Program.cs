using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int start = int.Parse(Console.ReadLine());
            while (numbers.Count < 10)
            {
                try
                {
                    int next = int.Parse(Console.ReadLine());
                    numbers.Add(next);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Number!");
                }
                //catch(ArgumentException)
                //{
                //    Console.WriteLine($"Your number is not in range {start} - 100!");
                //}
            }
        }
    }
}
