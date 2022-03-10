using System;
using System.Collections.Generic;
using System.Linq;

namespace p01BakeryShop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double[] waterInput = Console.ReadLine().Split(' ')
                                      .Select(double.Parse).ToArray();
            double[] flourInput = Console.ReadLine().Split(' ')
                                                 .Select(double.Parse).ToArray();

            Queue<double> water = new Queue<double>(waterInput);
            Stack<double> flour = new Stack<double>(flourInput);

            int croissant = 0;
            int muffin = 0;
            int baguette = 0;
            int bagel = 0;

            while (water.Count > 0 && flour.Count > 0)
            {
                double currentWater = water.Peek();
                double currentFlour = flour.Peek();

                double sumOfProducts = currentWater + currentFlour;

                double percentWater = Math.Round((currentWater * 100) / sumOfProducts);
                double percentFlour = 100 - percentWater;

                if (percentWater == 50 && percentFlour == 50)
                {
                    croissant++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (percentWater == 40 && percentFlour == 60)
                {
                    muffin++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (percentWater == 30 && percentFlour == 70)
                {
                    baguette++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (percentWater == 20 && percentFlour == 80)
                {
                    bagel++;
                    water.Dequeue();
                    flour.Pop();
                }
                else
                {
                    double diffBetwenProducts = currentFlour - currentWater;

                    currentFlour -= diffBetwenProducts;
                    croissant++;
                    water.Dequeue();
                    flour.Pop();
                    flour.Push(diffBetwenProducts);
                }
            }
            var products = new Dictionary<string, double>();
            products["Muffin"] = muffin;
            products["Bagel"] = bagel;
            products["Croissant"] = croissant;
            products["Baguette"] = baguette;

            foreach (var product in products.OrderByDescending(q => q.Value).ThenBy(n => n.Key))
            {
                if (product.Value<=0)
                {
                    continue;
                }
                Console.WriteLine($"{ product.Key}: { product.Value}");
            }
            if (water.Count <= 0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }
            if (flour.Count <= 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }

        }
    }
}
