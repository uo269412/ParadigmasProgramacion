using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using linked.list;

namespace concurrent.queue
{
    public class ConcurrentQueue<T>
    {
        private linked.list.List<T> List;
        private System.Threading.ReaderWriterLockSlim cacheLock = new System.Threading.ReaderWriterLockSlim(); //THREAD SAFE
        public System.Threading.ReaderWriterLockSlim CacheLock { get => cacheLock; set => cacheLock = value; }

        public ConcurrentQueue()
        {
            this.List = new linked.list.List<T>();
        }

        public int NumberOfElements { get
            {return List.Size;}}

        public bool IsEmpty()
        {
            CacheLock.EnterReadLock();
            try
            {
                if (NumberOfElements != 0)
                {
                    return false;
                }
                return true;
            } finally
            {
                CacheLock.ExitReadLock();
            }
        }

        public void Enqueue(T element)
        {
            CacheLock.EnterWriteLock();
            try
            {
                List.Add(element);
            } finally
            {
                CacheLock.ExitWriteLock();
            }

        }

        public T Dequeue()
        {
            T returnValue = default(T);
            CacheLock.EnterWriteLock();
                try
                {
                    List.RemoveAt0();
                }
                finally
                {
                    CacheLock.ExitWriteLock();
                }
            return returnValue;
        }

        public T Peek()
        {
            T returnValue = default(T);
            CacheLock.EnterReadLock();
            try
            {
                returnValue = List.GetElement(0);
            }
            finally
            {
                CacheLock.ExitReadLock();
            }
            return returnValue;
        }


        ~ConcurrentQueue()
        {
            if (CacheLock != null) CacheLock.Dispose();
        }
    }
}
