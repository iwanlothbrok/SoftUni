
using System;
using System.Linq;
namespace ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] names = Console.ReadLine().Split(' ');
            Action<string[]> print = n => Console.WriteLine(string.Join(Environment.NewLine,n));

            print(names);
        }
    }
}
