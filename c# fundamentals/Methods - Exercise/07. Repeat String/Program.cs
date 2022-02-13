using System;

namespace _07.RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            RepeatingSting(text, n);
        }
        static void RepeatingSting(string text, int num)
        {
            for (int i = 0; i < num; i++)
            {
                Console.Write(text);
            }
        }
    }
}
