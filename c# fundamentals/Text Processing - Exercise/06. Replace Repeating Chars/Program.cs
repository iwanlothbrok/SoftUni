
using System;
using System.Linq;
using System.Collections.Generic;
namespace ReplaceChars

{
    class Program
    {
        static void Main(string[] args)
        {
            string tokens = Console.ReadLine();
            int index = tokens.Length;
            for (int i = 0; i < index - 1; i++)
            {
                var token = tokens[i];
                var secondToken = tokens[i + 1];

                if (token == secondToken)
                {
                    tokens = tokens.Remove(i, 1);
                    index--;
                    i--;
                }
            }
            // tokens.Split(' ');
            Console.WriteLine(tokens);
        }
    }
}