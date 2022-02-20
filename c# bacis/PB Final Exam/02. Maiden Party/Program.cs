using System;
using System.Linq;
using System.Collections.Generic;
namespace MaidenParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double lovePoemPrice = 0.60;
            double rosePrice = 7.20;
            double keychainPice = 3.60;
            double caricaturePrice = 18.20;//,
            double suprisePrice = 22;

            double priceForParty = double.Parse(Console.ReadLine());
            int countPoem = int.Parse(Console.ReadLine());
            int countRose = int.Parse(Console.ReadLine());
            int countKeychain = int.Parse(Console.ReadLine());
            int countCaricature = int.Parse(Console.ReadLine());
            int countSuprice = int.Parse(Console.ReadLine());
            double totalPrice = (lovePoemPrice * countPoem)
                + (rosePrice * countRose) +
                (keychainPice * countKeychain) +
                caricaturePrice * countCaricature +
                (suprisePrice * countSuprice);

            int productsCount = countPoem + countRose + countKeychain + countCaricature + countSuprice;
            if (productsCount >= 25)
            {
                totalPrice *= 0.65;
            }

            totalPrice *= 0.9;
            if (totalPrice > priceForParty)
            {
                Console.WriteLine($"Yes! {totalPrice - priceForParty:F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {priceForParty-totalPrice:F2} lv needed.");
            }
        }
    }
}
