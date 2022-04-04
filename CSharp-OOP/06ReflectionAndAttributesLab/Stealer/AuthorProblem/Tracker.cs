using System;
using System.Linq;
using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            foreach (var method in methods)
            {
                if (method.CustomAttributes .Any(n => n.AttributeType == typeof(AuthorAttribute)))
                {
                    var attribute = method.GetCustomAttributes(false);
                    foreach (AuthorAttribute author in attribute)
                    {
                        Console.WriteLine($"{method.Name} is written by {author.Name}");
                    }
                }
            }
        }
    }
}
