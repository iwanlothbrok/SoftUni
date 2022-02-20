using System;
using System.Linq;
using System.Collections.Generic;
namespace QueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
         
                int[] commands = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int n = commands[0];
                int s = commands[1];
                int x = commands[2];
                int[] numbersArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> numbers = new Queue<int>();

                for (int i = 0; i < n; i++)
                {
                    numbers.Enqueue(numbersArr[i]);
                }
                for (int i = 0; i < s; i++)
                {
                    numbers.Dequeue();
                }
                if (numbers.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else if (!numbers.Any())
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(numbers.Min());
                }

            }
        }
    }
