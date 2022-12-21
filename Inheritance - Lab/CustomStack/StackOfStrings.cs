using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    internal class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (this.Count == 0)
            {
                return true;
            }
            return false;
        }
        public void AddRange(string[] range)
        {
            for (int i = 0; i < range.Length; i++)
            {
                this.Push(range[i]);
            }
        }
    }
}
