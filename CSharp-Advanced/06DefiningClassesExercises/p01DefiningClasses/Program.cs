using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = "Peter";
            int age = 20;
            Person pesho = new Person()
            {
                Name = name,
                Age = age
            };
            Console.WriteLine($"{pesho.Name} --> {pesho.Age}");
        }
    }
}
