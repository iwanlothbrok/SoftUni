using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int litersInTank = 0;
            int countIncomeLiters = 0;
            while (n > countIncomeLiters)//>=
            {
                int litersIncome = int.Parse(Console.ReadLine());
                countIncomeLiters++;
                litersInTank += litersIncome;
                if (litersIncome > 255 || litersInTank > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    litersInTank -= litersIncome;
                    continue;
                }



            }
            Console.WriteLine(litersInTank);
        }
    }
}
