using System;
using System.Linq;
using System.Collections.Generic;
namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine();

            var stack = new Stack<char>();

            foreach (char item in input)
            {
                stack.Push(item);
            }
            while (stack.Count != 0)
            {
                Console.Write(stack.Pop() + "");
            }
            
        }
    }
}