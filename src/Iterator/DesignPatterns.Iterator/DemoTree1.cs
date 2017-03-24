using System;
using System.Collections.Generic;

namespace DesignPatterns.Iterator
{
    public class DemoTree1<T>
    {
        public DemoTree1() { }

        public DemoTree1(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public DemoTree1<T> LeftChild { get; set; }
        public DemoTree1<T> RightChild { get; set; }

        public void Add(T value)
        {
            if (LeftChild == null)
            {
                LeftChild = new DemoTree1<T>(value);
            }
            else if (RightChild == null)
            {
                RightChild = new DemoTree1<T>(value);
            }
            else if (LeftChild.Depth() < RightChild.Depth())
            {
                LeftChild.Add(value);
            }
            else
            {
                RightChild.Add(value);
            }
        }

        public int Depth()
        {
            if (LeftChild ==  null || RightChild == null)
                return 0;

            return 1 + Math.Max(LeftChild.Depth(), RightChild.Depth());
        }

        // Old implementation, use IEnumerable instead. Breaks SRP and Open/Close principle
        public List<T> ToList()
        {
            var list = new List<T>();

            list.Add(Value);
            if (LeftChild != null)
            {
                list.AddRange(LeftChild.ToList());
            }
            if (RightChild != null)
            {
                list.AddRange(RightChild.ToList());
            }

            return list;
        }
    }
}
