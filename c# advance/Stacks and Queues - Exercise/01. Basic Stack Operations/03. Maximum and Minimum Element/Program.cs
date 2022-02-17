using System;
using System.Linq;
using System.Collections.Generic;
namespace MaximumAndMinimumElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] cmd = Console.ReadLine().Split(' ')
                    .Select(int.Parse).ToArray();

                int command = cmd[0];

                switch (command)
                {
                    case 1:
                        int numberToPush = cmd[1];
                        stack.Push(numberToPush);
                        break;

                    case 2:
                        stack.Pop();
                        break;

                    case 3:
                        if (stack.Any())
                        {
                            Console.WriteLine(stack.Max());
                        }

                        break;

                    case 4:
                        if (stack.Any())
                        {
                            Console.WriteLine(stack.Min());
                        }
                        break;

                    default:
                        break;
                }
            }
            Console.WriteLine(String.Join(", ",stack));
        }
    }
}

