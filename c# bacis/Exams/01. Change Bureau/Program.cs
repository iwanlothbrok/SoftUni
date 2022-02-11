using System;

namespace po_01._Change_Bureau
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitcoinCounter = int.Parse(Console.ReadLine());
            double chinaMoney = double.Parse(Console.ReadLine());
            double commission = double.Parse(Console.ReadLine());

            double onePriceBitcoin = 1168;//leva
            double chineseMoneyPrice = 0.15; //dollars 
            double chineseMoneyInLeva = chinaMoney * (chineseMoneyPrice * 1.76);

            double totalLeva = (bitcoinCounter * 1168) + (chineseMoneyInLeva);
            double totalEuro = totalLeva / 1.95;

            double commissionPrice = totalEuro * (commission / 100);


            Console.WriteLine($"{totalEuro - commissionPrice:f2}");

        }
    }
}
