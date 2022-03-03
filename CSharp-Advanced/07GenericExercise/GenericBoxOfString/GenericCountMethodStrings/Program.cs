using System;
using System.Collections.Generic;

namespace GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> input = new List<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string cmd = Console.ReadLine();

                input.Add(cmd);
            }
            string elementToCompare = Console.ReadLine();
            Box<string> box = new Box<string>(input);

           int result= box.CountDetector(input, elementToCompare);
            Console.WriteLine(result);
        }
    }
}
