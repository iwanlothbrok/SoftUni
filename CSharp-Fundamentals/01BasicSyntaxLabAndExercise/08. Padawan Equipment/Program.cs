using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int countOfStudens = int.Parse(Console.ReadLine());
            double priceForBlade = double.Parse(Console.ReadLine());
            double priceForRobe = double.Parse(Console.ReadLine());
            double priceForBelt = double.Parse(Console.ReadLine());//one is free,every 6 studnets

            double afterProcent = (Math.Ceiling(countOfStudens * 1.1));
            int countOfStudentsForBelt = 0;
            for (int i = 1; i <= countOfStudens; i++)
            {
                countOfStudentsForBelt++;
                if (i % 6 == 0)
                {
                    countOfStudentsForBelt -= 1;
                }
            }
            double totalMoney = priceForBlade * afterProcent + priceForRobe * countOfStudens + priceForBelt * countOfStudentsForBelt;



            if (amountOfMoney >= totalMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {totalMoney:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {totalMoney - amountOfMoney:f2}lv more.");
            }

        }
    }
}

