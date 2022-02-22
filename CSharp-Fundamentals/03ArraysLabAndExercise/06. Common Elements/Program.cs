using System;

namespace _02.CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] firstElement = Console.ReadLine().Split(" ");
            string[] secondElement = Console.ReadLine().Split(" ");

            foreach (string elementTwo in secondElement)
            {
                for (int j = 0; j < firstElement.Length; j++)
                {
                    if (elementTwo == firstElement[j])
                    {
                        Console.Write(elementTwo + " ");
                    }
                }
            }
        }
    }
}
