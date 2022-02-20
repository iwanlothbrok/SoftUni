using System;

namespace _06.Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (input.Length % 2 == 0)
            {
                string evenOutput = EvenLenghtString(input);
                Console.WriteLine(evenOutput);
            }
            else
            {
                string oddOutput = OddLenghtString(input);
                Console.WriteLine(oddOutput);
            }

        }

        private static string OddLenghtString(string input)
        {
            int index = input.Length / 2;
            string oddOutput = input.Substring(index, 1);
            return oddOutput;
        }

        private static string EvenLenghtString(string input)
        {
            int index = input.Length / 2;
            string evenOutput = input.Substring(index - 1, 2);
            return evenOutput;
        }
    }
}
