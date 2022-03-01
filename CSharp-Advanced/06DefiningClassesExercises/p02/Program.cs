using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            Person personSecond = new Person(20);
            Person personThird = new Person("Peter", 20);

            Console.WriteLine($"{person.Name} --> {person.Age}");
            Console.WriteLine($"{personSecond.Name} --> {personSecond.Age}");
            Console.WriteLine($"{personThird.Name} --> {personThird.Age}");
        }
    }
}
