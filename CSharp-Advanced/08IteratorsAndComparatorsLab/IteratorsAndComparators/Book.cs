

using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Book
    {
        public Book(string title, int year,params string[] names)
        {
            Title = title;
            Year = year;
            Authors = names;
        }
        public string Title { get; set; }

        public int Year { get; set; }

        public IReadOnlyList<string> Authors;
    }
}
