using System;

namespace fruitsOrVeg
{
    class Program
    {
        static void Main(string[] args)
        {
            string food = Console.ReadLine();

            if (food == "banana"

               || food == "cherry"
               || food == "apple"
               || food == "lemon"
               || food == "kiwi"
               || food == "grapes")

            {
                Console.WriteLine("fruit");
            }
            else if (food == "tomato" || food == "carrot" || food == "pepper" || food == "cucumber")
            {

                Console.WriteLine("vegetable");
            }
            else

            {
                Console.WriteLine("unknown");
            }

        }
    }
}
