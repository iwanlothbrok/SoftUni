using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        Stack<T> box;
        public int Count
        {
            get
            {
                return box.Count;
            }
        }


        public Box()
        {
            box = new Stack<T>();
            
        }

        public void Add(T element)
        {
            box.Push(element);
           
        }

        public T Remove()
        {
            if (Count == 0)
            {
                throw new Exception("PROBLEM ALERT!!!");
            }
            else
            {
                return box.Pop();
            }

        }



    }
}

