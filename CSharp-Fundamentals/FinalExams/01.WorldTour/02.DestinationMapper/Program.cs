

using System.Text.RegularExpressions;

namespace _03.PlantDiscovery
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            string pattern = @"([\=|\/])([?<destination>[A-Z][A-Za-z]{2,})\1";
                
            MatchCollection match = Regex.Matches(input, pattern);

            Console.Write("Destination ");
            Console.Write(string.Join(", ",match));
        }
    }
}

