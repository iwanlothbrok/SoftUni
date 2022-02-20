using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FancyBarcode

{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"@\#+[A-Z][A-Za-z0-9]{4,}[A-Z]@\#+";
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);
                string sum = string.Empty;
                if (match.Success)
                {
                    for (int j = 0; j < match.Length; j++)
                    {
                        if (Char.IsDigit(match.Value[j]))
                        {
                            sum += match.Value[j];
                        }

                    }
                    if (sum == "")
                    {
                        Console.WriteLine("Product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {sum}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
