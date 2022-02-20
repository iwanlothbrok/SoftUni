using System;

namespace _09.Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = Console.ReadLine();
            var firstText = Console.ReadLine();
            var secondText = Console.ReadLine();
            var result = GetMax(type, firstText, secondText);
            Console.WriteLine(result);

        }
        static string GetMax(string type, string firstText, string secondText)
        {
            var firstResult = 0;
            var secondResult = 0;
            if (type == "int")
            {
                firstResult = int.Parse(firstText);
                secondResult = int.Parse(secondText);
            }
            else if (type == "char")
            {
                firstResult = char.Parse(firstText);
                secondResult = char.Parse(secondText);
            }
            else if (type == "string")
            {
                int comprasions = firstText.CompareTo(secondText);
                if (comprasions > 0)
                {
                    return firstText;
                }
                else
                {
                    return secondText;
                }
            }
            if (firstResult > secondResult)
            {
                return firstText;

            }
            else
            {
                return secondText;
            }

        }

    }
}
