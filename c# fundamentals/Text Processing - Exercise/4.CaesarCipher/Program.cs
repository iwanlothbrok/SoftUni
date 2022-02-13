
using System;
using System.Linq;
using System.Collections.Generic;
namespace CesarCipher

{
    class Program
    {
        static void Main(string[] args)
        {
            string tokens = Console.ReadLine();
            for (int i = 0; i < tokens.Length; i++)
            {
                
                
                char token = tokens[i];
               
                int output = ((char)token + 3);
                Console.Write((char)output);
            }

        }
    }
}