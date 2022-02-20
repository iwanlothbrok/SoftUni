using System;
using System.Linq;
using System.Collections.Generic;
namespace ExcursionSALE
{
    class Program
    {
        static void Main(string[] args)
        {
            int seaTourCount = int.Parse(Console.ReadLine());
            int mountineTourCount = int.Parse(Console.ReadLine());
            int priceForSea = 680;
            int priceForMountine = 499;

            string command = Console.ReadLine();
            int totalPrice = 0;
            while (command != "Stop")
            {
                int seaCount = 0;
                int mountineCount = 0;
                if (command == "sea")
                {
                    if (seaTourCount == 0)
                    {

                        command = Console.ReadLine();
                        continue;
                    }
                    seaTourCount--;
                    totalPrice += priceForSea;
                }
                else
                {
                    if (mountineTourCount == 0)
                    {

                        command = Console.ReadLine();
                        continue;
                    }
                    mountineTourCount--;
                    totalPrice += priceForMountine;
                }
                if (mountineTourCount <= 0 && seaTourCount <= 0)
                {
                    Console.WriteLine("Good job! Everything is sold.");
                    break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Profit: {totalPrice} leva.");
        }
    }
}
