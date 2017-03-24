using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.Iterator
{
    public class DemoTreeEnumerator<T> : IEnumerator<T>
    {
        private DemoTree2<T> _tree;
        private DemoTree2<T> _current;
        private DemoTree2<T> _previous;
        private Stack<DemoTree2<T>> _breadcrumb = new Stack<DemoTree2<T>>();

        public DemoTreeEnumerator(DemoTree2<T> tree)
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
                return true;
            }
            if (_current.LeftChild != null)
            {
                return TraverseLeft();
            }
            if (_current.RightChild != null)
            {
                return TraverseRight();
            }

            return TraverseUpAndRight();
        }

        public void Reset()
        {
            _current = null;
        }

        public void Dispose() { }

        private bool TraverseLeft()
        {
            _breadcrumb.Push(_current);
            _current = _current.LeftChild;

            return true;
        }

        private bool TraverseRight()
        {
            _breadcrumb.Push(_current);
            _current = _current.RightChild;

            return true;
        }

        private bool TraverseUpAndRight()
        {
            if (_breadcrumb.Count > 0)
            {
                _previous = _current;
                while (true)
                {
                    _current = _breadcrumb.Pop();
                    if (_previous != _current.RightChild) 
                        break;
                }
                if (_current.RightChild != null)
                {
                    _breadcrumb.Push(_current);
                    _current = _current.RightChild;
                    return true;
                }
            }
            return false;
        }
    }
}
