using System;
using System.Collections.Generic;

namespace ComparingObjectsProblem
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string cmd = Console.ReadLine();
            while (cmd != "END")
            {
                string[] tokens = cmd.Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];

                Person person = new Person(name, age, town);
                people.Add(person);
                cmd = Console.ReadLine();
            }

            int n = int.Parse(Console.ReadLine());

            Person neededGuy = people[n - 1];
            int personMatches = 0;
            int notMatches = 0;

            foreach (Person person in people)
            {
                int res = person.CompareTo(neededGuy);
                if (res==0)
                {
                    personMatches++;
                }
                else
                {
                    notMatches++;
                }
            }

            if (personMatches == 1)
            {
                Console.WriteLine("No matches");//
            }
            else
            {
                Console.WriteLine($"{personMatches} {notMatches} {people.Count}");
            }
        }
    }
}
