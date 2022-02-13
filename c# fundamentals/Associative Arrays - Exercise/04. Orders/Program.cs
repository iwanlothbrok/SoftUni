
using System;
using System.Linq;
using System.Collections.Generic;
namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {


            var products = new Dictionary<string, List<double>>();
            string command = Console.ReadLine();

            while (command != "buy")
            {
                string[] cmdArr = command.Split();
                string product = cmdArr[0];
                double price = double.Parse(cmdArr[1]);
                double quantity = double.Parse(cmdArr[2]);

                if (products.ContainsKey(product) == false)
                {
                    List<double> priceAndQuantity = new List<double> { price, quantity };
                    products.Add(product, priceAndQuantity);
                }
                else
                {
                    products[product][0] = price;
                    products[product][1] += quantity;
                }
                command = Console.ReadLine();
            }
            foreach (var product in products)
            {
                double totalPrice = product.Value[0] * product.Value[1];
                Console.WriteLine($"{product.Key} -> {totalPrice:f2}");
            }
        }
    }
}