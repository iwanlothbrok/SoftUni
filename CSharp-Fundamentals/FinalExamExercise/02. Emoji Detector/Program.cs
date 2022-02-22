using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            var emojiPattern = @"(\:{2}|\*{2})[A-Z][a-z]{2,}\1";

            var digits = @"\d";
            var regex = new Regex(digits);//for digits 
            MatchCollection digit = regex.Matches(text);//for digits

            long holder = 1;

            foreach (Match num in digit)
            {
                int number = int.Parse(num.Value);

                holder *= number;
            }

            Console.WriteLine($"Cool threshold: {holder}");

            regex = new Regex(emojiPattern);
            var matches = regex.Matches(text);
            int count = matches.Count();
            List<string> coolEmojis = new List<string>();
            foreach (Match match in matches)
            {
               long coolIndex = match.Value.Substring(2, match.Value.Length - 4)
                    .ToCharArray()
                    .Sum(x => (int)x);

                if (coolIndex>holder)
                {
                    coolEmojis.Add(match.Value);    
                }
            }
            Console.WriteLine($"{count} emojis found in the text. The cool ones are:");
            foreach (var item in coolEmojis)
            {
                Console.WriteLine(item);
            }

        }
    }
}