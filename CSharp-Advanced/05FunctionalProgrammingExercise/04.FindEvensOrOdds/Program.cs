
using System;
using System.Linq;
using System.Collections.Generic;


namespace FindEvenOrOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] startAndEnd = Console.ReadLine().Split(' ')
                                .Select(int.Parse).ToArray();

            int start = startAndEnd[0];
            int end = startAndEnd[1];
            string command = Console.ReadLine();

            Func<int, int, List<int>> func = (start, end) =>
              {
                  List<int> list = new List<int>();
                  for (int i = start; i <= end; i++)
                  {
                      list.Add(i);
                  }
                  return list;
              };
            List<int> numbers = func(start, end);

            Predicate<int> evenPredicate = numbers => numbers % 2 == 0;
            Predicate<int> oddPredicate = numbers => numbers % 2 != 0;

            var oddNums = numbers.FindAll(oddPredicate);
            var evenNums = numbers.FindAll(evenPredicate);
            if (command == "odd")
            {
                Console.WriteLine(String.Join(" ",oddNums));
            }
            else if (command == "even")
            {
                Console.WriteLine(String.Join(" ", evenNums));
            }

        }
    }
}
