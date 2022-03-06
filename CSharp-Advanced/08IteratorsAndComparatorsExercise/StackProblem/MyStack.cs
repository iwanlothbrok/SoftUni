using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackProblem
{
    public class MyStack<T> : IEnumerable<T>
    {
        public MyStack()
        {
            items = new List<T>();
        }
        private List<T> items;
        public int Count => items.Count;

        public void Push(T element)
        {
            items.Add(element);
        }
        public T Pop()
        {
           
            T item = items.Last();
            items.RemoveAt(items.Count-1);

            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }
}
