using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string dateOne = Console.ReadLine();
            string dateTwo = Console.ReadLine();

           DateModifier dateModifier = new DateModifier();

            Console.WriteLine($"{dateModifier.CalculatorDiffrence(dateOne,dateTwo)}");
        }

    }
}
