using System;

namespace _05.Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int sum = SumOfFirstAndSecondNum(firstNum, secondNum, thirdNum);
            Console.WriteLine(sum);
        }

        private static int SumOfFirstAndSecondNum(int firstNum, int secondNum, int thirdNum)
        {
            int sum = firstNum + secondNum;
            int totalSum = TotalSumAfterSubtracks(sum, thirdNum);
            return totalSum;
        }

        private static int TotalSumAfterSubtracks(int sum, int thirdNum)
        {
            return sum - thirdNum;
        }
    }
}
