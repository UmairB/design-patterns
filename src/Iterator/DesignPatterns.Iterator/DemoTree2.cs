using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.Iterator
{
    public class DemoTree2<T> : IEnumerable<T>
    {
        public DemoTree2() { }

        public DemoTree2(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public DemoTree2<T> LeftChild { get; set; }
        public DemoTree2<T> RightChild { get; set; }

        public void Add(T value)
        {
            if (LeftChild == null)
            {
                LeftChild = new DemoTree2<T>(value);
            }
            else if (RightChild == null)
            {
                RightChild = new DemoTree2<T>(value);
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

        public IEnumerable<DemoTree2<T>> Children()
        {
            if (LeftChild != null)
            {
                yield return LeftChild;
            }
            if (RightChild != null)
            {
                yield return RightChild;
            }

            yield break;
        }

        public bool UseBreadthFirstEnumerator { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            if (UseBreadthFirstEnumerator)
            {
                return new DemoTreeBreadthFirstEnumerator<T>(this);
            }

            return new DemoTreeEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
