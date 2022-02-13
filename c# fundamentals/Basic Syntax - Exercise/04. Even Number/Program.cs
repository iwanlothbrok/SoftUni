using System;

namespace po_12._Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            bool evenSum = false;

            while (evenSum != true)
            {
                if (num % 2 == 0)
                {
                    evenSum = true;
                    Console.WriteLine($"The number is: {Math.Abs(num)}");
                    break;
                }
                else
                {
                    Console.WriteLine("Please write an even number.");
                }
                num = int.Parse(Console.ReadLine());
            }

        }
    }
}
