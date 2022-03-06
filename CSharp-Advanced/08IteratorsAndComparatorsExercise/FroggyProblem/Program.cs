using System;
using System.Linq;

namespace FroggyProblem
{
    public class Program
    {
        static void Main(string[] args)
        {
            var stoneValues = Console.ReadLine()
             .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse);

            var stones = new Stones<int>(stoneValues);

            Console.WriteLine(string.Join(", ", stones));
        }
    }
}
