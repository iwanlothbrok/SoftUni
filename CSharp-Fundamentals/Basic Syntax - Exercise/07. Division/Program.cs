using System;

namespace _02._Divison
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //: 2, 3, 6, 7, 10
            string result = string.Empty;

            if (n % 10 == 0)
            {
                result = "The number is divisible by 10";
            }
            else if (n % 7 == 0)
            {
                result = "The number is divisible by 7";
            }
            else if (n % 6 == 0)
            {
                result = "The number is divisible by 6";
            }
            else if (n % 3 == 0)
            {
                result = "The number is divisible by 3";
            }
            else if (n % 2 == 0)
            {
                result = "The number is divisible by 2";
            }
            else
            {
                result = "Not divisible";
            }
            Console.WriteLine(result);
        }
    }
}
