using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.Iterator
{
    public class DemoTreeBreadthFirstEnumerator<T> : IEnumerator<T>
    {
        private readonly DemoTree2<T> _tree;
        private DemoTree2<T> _current;
        private Queue<IEnumerator<DemoTree2<T>>> _enumerators = new Queue<IEnumerator<DemoTree2<T>>>();

        public DemoTreeBreadthFirstEnumerator(DemoTree2<T> tree)
        {
            _tree = tree;
        }

        public T Current => _current.Value;

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (_current == null)
            {
                Reset();
                _current = _tree;
                _enumerators.Enqueue(_current.Children().GetEnumerator());
                return true;
            }
            while (_enumerators.Count > 0)
            {
                var enumerator = _enumerators.Peek();
                if (enumerator.MoveNext())
                {
                    _current = enumerator.Current;
                    _enumerators.Enqueue(_current.Children().GetEnumerator());
                    return true;
                }
                else
                {
                    _enumerators.Dequeue();
                }
            }
            return false;
        }

        public void Reset()
        {
            _current = null;
            _enumerators.Clear();
        }

        public void Dispose()
        {
        }
    }
}
