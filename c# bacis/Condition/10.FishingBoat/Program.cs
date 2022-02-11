using System;

namespace flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowers = Console.ReadLine();
            int countFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());


            double priceForFlower = 0.0;
            double allPrice = 0.0;


            if (flowers == "Roses" && countFlowers > 80)
            {
                allPrice = countFlowers * 5 * 0.9;
            }
            else if (flowers == "Roses")
            {
                allPrice = countFlowers * 5;
            }

            if (flowers == "Dahlias" && countFlowers > 90)

            {
                allPrice = (countFlowers * 3.80) * 0.85;
            }
            else if (flowers == "Dahlias")
            {
                allPrice = countFlowers * 3.80;
            }
            if (flowers == "Tulips" && countFlowers > 80)
            {
                allPrice = countFlowers * 2.80 * 0.85;
            }
            else if (flowers == "Tulips")
            {
                allPrice = countFlowers * 2.80;
            }
            if (flowers == "Narcissus" && countFlowers < 120)
            {
                allPrice = countFlowers * 3 * 1.25;
            }
            else if (flowers == "Narcissus")
            {
                allPrice = countFlowers * 3;
            }
            if (flowers == "Gladiolus" && countFlowers < 80)
            {
                allPrice = countFlowers * 2.50 * 1.20;
            }
            else if (flowers == "Gladiolus")
            {
                allPrice = countFlowers * 2.50;
            }

            if (allPrice > budget)
            {
                Console.WriteLine($"Not enough money, you need {allPrice - budget:f2} leva more.");
            }
            else
            {
                Console.WriteLine($"Hey, you have a great garden with {countFlowers} {flowers} and {budget - allPrice:f2} leva left.");
            }

        }

    }
}

