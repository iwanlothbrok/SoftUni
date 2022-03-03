using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var problem = new EqualityScale<int>(5, 5);

            Console.WriteLine(problem.AreEqual());
        }
    }
}
