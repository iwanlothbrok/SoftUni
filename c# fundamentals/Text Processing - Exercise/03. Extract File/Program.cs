
using System;
using System.Linq;
using System.Collections.Generic;
namespace ExtractFile

{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split('\\');
            var tokens = words[words.Length - 1].Split('.');
            Console.WriteLine($"File name: {tokens[0]}");
            Console.WriteLine($"File extension: {tokens[1]}");

        }
    }
}