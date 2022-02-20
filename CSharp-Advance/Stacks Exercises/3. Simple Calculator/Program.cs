using System;
using System.Linq;
using System.Collections.Generic;
namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            Stack<string> stack = new Stack<string>(input.Reverse());
            int sum = 0;
            while (stack.Count > 1)
            {

                int leftN = int.Parse(stack.Pop());
                string cmd = stack.Pop();
                int right = int.Parse(stack.Pop());

                if (cmd == "+")
                {
                    stack.Push((leftN + right).ToString());
                }
                else
                {
                    stack.Push((leftN - right).ToString());
                }

            }

            Console.WriteLine(stack.Pop());
        }
    }
}