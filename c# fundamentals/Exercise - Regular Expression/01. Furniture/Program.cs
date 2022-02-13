using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @">>(?<name>[A-Za-z]+)<<(?<price>\d+(.\d+)?)!(?<quant>\d+)";
            var names = new List<string>();
            string command = Console.ReadLine();
            double sum = 0;
            while (command != "Purchase")
            {
                Match match = Regex.Match(command, pattern);

                if (match.Success)
                {
                    var name = match.Groups["name"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quant"].Value);

                    names.Add(name);
                    sum += price * quantity;
                }



                command = Console.ReadLine();
            }
            Console.WriteLine("Bought furniture:");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine($"Total money spend: {sum}");
        }
    }
}