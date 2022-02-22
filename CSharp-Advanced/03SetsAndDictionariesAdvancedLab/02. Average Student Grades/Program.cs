using System;
using System.Linq;
using System.Collections.Generic;
namespace AverageGrades
{
    class Program
    {
        static void Main(string[] args)
        {

            int studentsCount = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < studentsCount; i++)
            {
                string[] cmdArr = Console.ReadLine().Split(' ');
                string name = cmdArr[0];
                decimal grade = decimal.Parse(cmdArr[1]);

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<decimal>());
                }
                students[name].Add(grade);
            }
            foreach (var student in students)
            {
                var name = student.Key;

                var studentGrades = student.Value;

                var avg = studentGrades.Average();

                Console.Write($"{name} -> ");

                foreach (var grade in studentGrades)

                    Console.Write($"{grade:f2} ");

                Console.WriteLine($"(avg: {avg:f2})");
            }
        }
    }
}