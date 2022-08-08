using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.ThePianist
{
    public class StartUp
    {

        static void Main(string[] args)
        {
            var pattern = @"([#|])(?<item>[a-zA-Z\s]+)(\1)(?<date>[0-9]{2}\/[0-9]{2}\/[0-9]{2})(\1)(?<calories>[0-9]+)\1";
            var input = Console.ReadLine();
            var matches = Regex.Matches(input, pattern);

            int calories = 0;
            foreach (Match match in matches)
            {
                var currentCalories = int.Parse(match.Groups["calories"].Value);
                if (currentCalories > 10000)
                {
                    
                    continue;
                }
                else
                {
                    calories += currentCalories;
                }
            }
            Console.WriteLine($"You have food to last you for: {calories / 2000} days!");
            foreach (Match match in matches)
            {
               
                Console.WriteLine($"Item: {match.Groups["item"].Value}, Best before: {match.Groups["date"].Value}, Nutrition: {match.Groups["calories"].Value}");
            }
        }
    }
}
