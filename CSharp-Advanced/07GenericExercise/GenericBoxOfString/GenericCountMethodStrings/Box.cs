using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodStrings
{
    public class Box<T> where T : IComparable
    {
        public Box(List<T> elements)
        {
            GetT = elements;
        }

        public List<T> GetT { get; set; }

       // public int Count { get => GetT.Count; }

        public int CountDetector(List<T> input, T inputElement)
        {
            int counter = 0;
            foreach (var item in input)
            {
                if (inputElement.CompareTo(item) < 0)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
