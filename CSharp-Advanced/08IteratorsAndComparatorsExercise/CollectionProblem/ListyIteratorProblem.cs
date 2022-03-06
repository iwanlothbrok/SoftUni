using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CollectionProblem
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        public ListyIterator(List<T> elements)
        {
            Elements = elements;
            CurrIndex = 0;
        }
        private List<T> Elements;
        private int CurrIndex;


        public int Count => this.Elements.Count;

        public bool Move()
        {
            if (HasNext())
            {
                CurrIndex++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if (CurrIndex < Elements.Count - 1)
            {
                return true;
            }
            return false;
        }
        public void Print()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(Elements[CurrIndex]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in Elements)
            {
                    yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
