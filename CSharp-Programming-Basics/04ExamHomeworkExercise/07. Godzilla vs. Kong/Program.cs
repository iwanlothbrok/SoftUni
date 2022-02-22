using System;

namespace GodzillaVsKingKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budgetFilm = double.Parse(Console.ReadLine());
            int peopleCount = int.Parse(Console.ReadLine());
            double suitPrice = double.Parse(Console.ReadLine());



            double priceDecor = budgetFilm * 0.1;

            double totalSuitPrice = peopleCount * suitPrice;

            if (peopleCount > 150)
            {
                totalSuitPrice *= 0.9;
            }

            double totalCost = priceDecor + totalSuitPrice;

            if (budgetFilm >= totalCost)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budgetFilm - totalCost:F2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {totalCost - budgetFilm:F2} leva more.");
            }
        }
    }
}
