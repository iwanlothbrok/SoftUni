using System;
using System.Linq;
using System.Collections.Generic;
namespace EvenNum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> numbers = new Queue<int>(input);


            for (int i = 0; i < numbers.Count; i++)
            {
                int num = numbers.Peek();
                if (num % 2 == 0)
                {
                    numbers.Dequeue();
                    numbers.Enqueue(num);
                }
                else
                {
                    numbers.Dequeue();
                    i--;
                }
            }
            Console.WriteLine(String.Join(", ",numbers));
        }
    }
}