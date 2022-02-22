using System;
using System.Linq;
using System.Collections.Generic;
namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            string command = Console.ReadLine().ToLower();
            Stack<int> stack = new Stack<int>(numbers);
            while (command != "end")
            {
                string[] cmdArr = command.Split();
                string cmd = cmdArr[0];
                if (cmd == "add")
                {
                    int firstNum = int.Parse(cmdArr[1]);
                    int secondNum = int.Parse(cmdArr[2]);

                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }
                else
                {
                    int n = int.Parse(cmdArr[1]);
                    if (stack.Count < n)
                    {

                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            stack.Pop();
                        }
                    }

                }
                command = Console.ReadLine().ToLower();
            }
            int sum = 0;
            for (int i = 0; i < stack.Count; i++)
            {

                int secondN = stack.Peek();
                sum += secondN;
                stack.Pop();
                i--;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}