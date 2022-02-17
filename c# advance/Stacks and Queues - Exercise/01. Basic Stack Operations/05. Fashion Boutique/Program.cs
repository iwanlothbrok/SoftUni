using System;
using System.Linq;
using System.Collections.Generic;
namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] incomingProducts = Console.ReadLine().Split(' ')
                           .Select(int.Parse).ToArray();
            Stack<int> products = new Stack<int>(incomingProducts);

            int capacity = int.Parse(Console.ReadLine());
            int currentCapacity = capacity;
            int count = 1;
            while (products.Any())
            {

                int currentProduct = products.Pop();
                if (currentCapacity > currentProduct)
                {
                    currentCapacity -= currentProduct;
                }
                else if (currentCapacity == currentProduct)
                {
                    currentCapacity -= currentProduct;
                    if (products.Any())
                    {
                        count++;
                    }

                    currentCapacity = capacity;
                }
                else
                {
                    count++;
                    currentCapacity = capacity;
                    currentCapacity -= currentProduct;
                }

            }
            Console.WriteLine(count);
        }
    }
}

