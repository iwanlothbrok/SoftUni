
using System;
using System.Linq;
using System.Collections.Generic;


namespace ArithmeticsFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ')
                                .Select(int.Parse).ToArray();
            Func<int, int> adding = n => n + 1;
            Func<int, int> multiply = n => n * 2;
            Func<int, int> subratct = n => n - 1;
            string command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {
                    case "add":numbers = numbers.Select(adding).ToArray();
                    
                         break;
                    case "multiply":
                        numbers = numbers.Select(multiply).ToArray();
                        break;
                    case "subtract":
                        numbers = numbers.Select(subratct).ToArray();
                        break;
                    case "print":
                        Console.WriteLine(String.Join(" ",numbers));
                        break;

                    default:
                        break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
