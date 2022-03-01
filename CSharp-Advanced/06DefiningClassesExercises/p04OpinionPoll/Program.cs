using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split();
                string name = cmd[0];
                int age = int.Parse(cmd[1]);

                Person person = new Person(name, age);
                persons.Add(person);
            }
            persons = persons.Where(x => x.Age > 30).ToList();
            foreach (Person person in persons.OrderBy(n => n.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
