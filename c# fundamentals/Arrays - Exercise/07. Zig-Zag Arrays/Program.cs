using System;

namespace _03.Zig_ZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] arr1 = new string[n];
            string[] arr2 = new string[n];
            for (int i = 0; i < n; i++)
            {
                string[] current = Console.ReadLine().Split(" ");

                string firstNum = current[0];
                string secondNum = current[1];


                if (i % 2 == 0)
                {
                    arr1[i] = firstNum;
                    arr2[i] = secondNum;

                }
                else
                {
                    arr1[i] = secondNum;
                    arr2[i] = firstNum;
                }


            }
            Console.WriteLine(string.Join(" ", arr1));
            Console.WriteLine(string.Join(" ", arr2));
        }
    }
}
