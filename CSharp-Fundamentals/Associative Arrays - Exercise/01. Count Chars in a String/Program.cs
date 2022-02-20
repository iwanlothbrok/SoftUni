
using System;
using System.Linq;
using System.Collections.Generic;
namespace CharsCount
{
    class Program
    {
        static void Main(string[] args)
        {

            char[] text = Console.ReadLine().ToCharArray();//[]
            var chars = new Dictionary<char, int>();

            foreach (char c in text)
            {
                if (c == ' ')
                {
                    continue;
                }
                if (chars.ContainsKey(c) == false)
                {
                    chars.Add(c, 0);
                }
                chars[c]++;
            }
            foreach (var c in chars)
            {
                Console.WriteLine($"{c.Key} -> {c.Value}");
            }

        }
    }
}