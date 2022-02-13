
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {

            string names = Console.ReadLine();
            string patterns = @"\b[A-Z][a-z]+ [A-Z][a-z]+";

            var regex = new Regex(patterns);
            MatchCollection matches = Regex.Matches(names, patterns);

            foreach (Match match in matches)
            {
                Console.Write(match.Value + " ");
            }
            Console.WriteLine();
        }
    }
}
