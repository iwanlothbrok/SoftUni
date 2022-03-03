using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodDoubles
{
    public class Box<T> where T : IComparable
    {
        public Box(List<T> elements)
        {
            GetT = elements;
        }

        public List<T> GetT { get; set; }

        public int CompareNumbers(List<T> elements, T toCompare)
        {
            int counter = 0;
            foreach (var element in elements)
            {
                if (toCompare.CompareTo(element) < 0)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
