using System;

namespace Square_Root
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            try
            {
                double result = Math.Sqrt(number);
                if (result.ToString() == "NaN")
                {
                    throw new ArgumentException("Invalid number.");
                }
                Console.WriteLine(result);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }


        }
    }
}
