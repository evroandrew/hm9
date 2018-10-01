using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.lib
{
    public class MyList<T> : IList<T>, IEnumerator<T>
    {

        #region fields
        private class ListItem
        {
            public T Value { get; set; }
            public ListItem Next { get; set; }
            public static ListItem operator ++(ListItem item)
            {
                return item.Next;
            }
        }
        private ListItem Head { get; set; }
        private ListItem Tail { get; set; }
        public int Count { get; private set; }
        #endregion

        private ListItem GetItem(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index Out Of Range");
            }
            ListItem item = Head;
            while (index-- > 0)
                item = item.Next;
            return item;
        }

        public bool IsReadOnly { get => false; }

        public T this[int index]
        {
            get => GetItem(index).Value;
            set => GetItem(index).Value = value;
        }

        public void Add(T item)
        {
            if ((Head == null) && (Tail == null))
            {
                Head = Tail = new ListItem { Value = item };
                Count = 1;
                return;
            }
            Tail = Tail.Next = new ListItem { Value = item };
            Count++;
        }

        public MyList()
        {
            Count = 0;
            Head = Tail = null;
        }
        //public MyList(IEnumerable<T> arr)
        //{
        //    using (IEnumerator<T> e = arr.GetEnumerator())
        //    {
        //        if (e.MoveNext())
        //        {
        //            Count = 1;
        //            Head = Tail = new ListItem { Value = e.Current };
        //            while (e.MoveNext())
        //            {
        //                Tail = Tail.Next = new ListItem { Value = e.Current };
        //            }
        //        }
        //        else
        //        {
        //            Count = 0;
        //            Head = Tail = null;
        //            return;
        //        }
        //            }
        //}

        public void Clear()
        {
            Head = Tail = null;
            Count = 0;
        }

        public bool Contains(T value)
        {
            //using (IEnumerator<T> e = GetEnumerator())
            //    while(e.MoveNext())
            //    if (e.Current.Equals(value)) return true;
            ListItem item = Head;
            while (item != null)
            {
                if (item.Value.Equals(value))
                    return true;
                item = item.Next;
            }
            return false;
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            if ((array.Length - arrayIndex) >= this.Count)
            {
                for (int i = 0; i < this.Count; i++)
                    array[arrayIndex + i] = this[i];
            }
            else
                throw new IndexOutOfRangeException("Index Out Of Range");
        }

        #region IEnumerator
        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }
        private int currentIndex = -1;
        public T Current
        {
            get => this[currentIndex];
        }
        object IEnumerator.Current => Current;
        public bool MoveNext()
        {
            ++currentIndex;
            return currentIndex <= Count - 1;
        }
        public void Reset()
        {
            currentIndex = -1;
        }
        public void Dispose()
        {
            Reset();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        public int IndexOf(T item)
        {
            if (this.Contains(item))
            {
                ListItem tmp = Head;
                for (int i = 0; i < this.Count; i++)
                {
                    if (tmp.Value.Equals(item))
                        return i;
                    tmp = tmp.Next;
                }
                return -1;
            }
            else
            {
                return -1;
            }
        }

        public void Insert(int index, T item)
        {
            if ((index > 0) && (index < Count))
            {
                ListItem temp, p = this.Head;
                temp = new ListItem { Value = item };
                int i = 0;
                do
                {
                    p = p.Next;
                    ++i;
                } while (i < index - 1);
                temp.Next = p.Next;
                p.Next = temp;
                Count++;
                return;
            }
            if(index==Count)
            {
                this.Add(item);
            }
            else
                throw new IndexOutOfRangeException("Index Out Of Range");

        }

        public bool Remove(T item)
        {
            if (this.IndexOf(item) == -1)
                return false;
            else
            {
                this.RemoveAt(this.IndexOf(item));
                return true;
            }
        }

        public void RemoveAt(int index)
        {
            if ((index > -1) && (index < Count))
            {
                ListItem temp, p = this.Head;
                if (index == 0)
                {
                    Head = Head.Next;
                    return;
                }
                if (index == Count - 1)
                {
                    for (int il = 0; il < Count - 1; il++)
                        p = p.Next;
                    Tail = p;
                    p.Next = null;
                    return;
                }
                int i = 0;
                do
                {
                    p = p.Next;
                    ++i;
                } while (i < index - 1);
                temp = p.Next.Next;
                p.Next = temp;
                Count--;
            }
        }
    }
}
