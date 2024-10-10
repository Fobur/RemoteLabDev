namespace BlazorApp1.Client.Models
{
    public class ConcurrentLinkedList<T> : IEnumerable<T>, ICollection<T>
    {
        private readonly LinkedList<T> _list;
        private readonly ReaderWriterLockSlim _lock;

        public int Count
        {
            get
            {
                try
                {
                    _lock.EnterReadLock();
                    return _list.Count;
                }
                finally
                {
                    _lock.ExitReadLock();
                }
            }
        }

        public bool IsReadOnly => false;

        public ConcurrentLinkedList() : this(null) { }

        public ConcurrentLinkedList(IEnumerable<T> items)
        {
            _list = items is null ? new LinkedList<T>() : new LinkedList<T>(items);
            _lock = new ReaderWriterLockSlim();
        }

        public void Add(T item)
        {
            try
            {
                _lock.EnterWriteLock();
                _list.AddFirst(item);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public void AddLast(T item)
        {
            try
            {
                _lock.EnterWriteLock();
                _list.AddLast(item);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public void Clear()
        {
            try
            {
                _lock.EnterWriteLock();
                _list.Clear();
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public bool Contains(T item)
        {
            try
            {
                _lock.EnterReadLock();
                return _list.Contains(item);
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            try
            {
                _lock.EnterReadLock();
                _list.CopyTo(array, arrayIndex);
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public bool Remove(T item)
        {
            try
            {
                _lock.EnterWriteLock();
                return _list.Remove(item);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        private IEnumerable<T> Enumerate()
        {
            try
            {
                _lock.EnterReadLock();
                foreach (T item in _list)
                    yield return item;
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public IEnumerator<T> GetEnumerator()
            => Enumerate().GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
            => Enumerate().GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
           return Enumerate().GetEnumerator();
        }
    }
}
