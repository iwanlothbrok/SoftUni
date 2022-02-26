
using System;
using System.Linq;
using System.Collections.Generic;


namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());

            List<int> dividers = Console.ReadLine().Split(' ')
                          .Select(int.Parse).ToList();

            Func<int, List<int>> func = end =>
             {
                 List<int> list = new List<int>();
                 for (int i = 1; i <= end; i++)
                 {
                     list.Add(i);
                 }
                 return list;
             };
            List<int> list = func(end);

            Func<List<int>, List<int>, List<int>> predicate = (numberInList, toSubract) =>
            {
                List<int> result = new List<int>();

                foreach (int n in numberInList)
                {
                    int count = 0;
                    foreach (int i in toSubract)
                    {
                        if (n % i == 0 )
                        {
                            count++;
                        }
                        if (count==toSubract.Count)
                        {
                            result.Add(n);
                        }
                    }
                }
                return result;
            };
            List<int> result = predicate(list, dividers);
            Console.WriteLine(String.Join(" ",result));
        }
    }
}
