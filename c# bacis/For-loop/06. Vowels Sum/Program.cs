﻿using System;

namespace vowelsSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int num = 0;


            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case 'a':
                        num += 1;
                        break;
                    case 'e':
                        num += 2;
                        break;
                    case 'i':
                        num += 3;
                        break;
                    case 'o':
                        num += 4;
                        break;
                    case 'u':
                        num += 5;
                        break;

                }

            }
            Console.WriteLine(num);

        }
    }
}
