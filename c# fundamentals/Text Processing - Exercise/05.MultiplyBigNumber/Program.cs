
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MultiplyBigN

{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            string longNum = Console.ReadLine().TrimStart('0');
            int secondN = int.Parse(Console.ReadLine());
            int temp = 0;
            if (secondN == 0 || longNum == "")
            {
                Console.WriteLine(0);
                return;
            }

            foreach (char ch in longNum.Reverse())
            {
                int digit = int.Parse(ch.ToString());
                int result = digit * secondN + temp;

                int restDigit = result % 10;
                temp = result / 10;
                sb.Insert(0, restDigit);
            }
            if (temp > 0)
            {
                sb.Insert(0, temp);
            }


            Console.WriteLine(sb.ToString());

        }
    }
}