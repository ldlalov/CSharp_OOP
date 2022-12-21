using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] range = new string[2];
            range[0] = "a";
            range[1] = "b";
            StackOfStrings stack = new StackOfStrings();
            stack.AddRange(range);
            Console.WriteLine(string.Join(" ", stack));
        }
    }
}
