using System;

namespace po_02._Mountain_Run
{
    class Program
    {
        static void Main(string[] args)
        {
            double imputRecordInSecond = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double inputTimeInSeconds = double.Parse(Console.ReadLine());

            double timeInSeconds = meters * inputTimeInSeconds;

            double metersAfterSlower = Math.Floor(meters / 50);
            metersAfterSlower = metersAfterSlower * 30;

            double totalSeconds = (Math.Abs(metersAfterSlower + timeInSeconds));


            if (totalSeconds < imputRecordInSecond)
            {
                Console.WriteLine($"Yes! The new record is {totalSeconds:F2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {totalSeconds - imputRecordInSecond:F2} seconds slower.");
            }


        }
    }
}
