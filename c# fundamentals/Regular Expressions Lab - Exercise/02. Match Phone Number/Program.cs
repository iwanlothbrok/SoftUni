using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine();
            var pattern = (@"(\+359([ -])2(\2)(\d{3})(\2)(\d{4}))\b");
            //var regex = new Regex(pattern);
            MatchCollection matches = Regex.Matches(numbers, pattern);
            var matchedPhones = matches
                .Cast<Match>().Select(v=>v.Value.Trim()).ToArray();


            Console.WriteLine(String.Join(", ",matchedPhones));
        }
    }
}