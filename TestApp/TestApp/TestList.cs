using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    public class TestList<T>
    {
        private T[] _items;
        private int _count;
        private int _capacity;

        public int Count
        {
            get
            {
                return this._count;
            }
            private set
            {
                this._count = value;
            }
        }
        public int Capacity
        {
            get
            {
                return this._capacity;
            }
            private set
            {
                this._capacity = value;
            }
        }

        public T this[int index]
        {
            get
            {
                return this._items[index];
            }
            set
            {
                this._items[index] = value;
            }
        }

        public TestList()
        {
            this._items = new T[2];
            this._capacity = 2;
            this._count = 0;
        }

        public void Add(T item)
        {
            if(this._capacity == this._count)
            {
                T[] clone = (T[])_items.Clone();

                this._capacity *= 2;
                this._items = new T[this._capacity];

                Array.Copy(clone, 0, this._items, 0, clone.Length);
            }
            this._items[this._count] = item;
            this._count++;
        }

        public static TestList<T> operator + (TestList<T> list1, TestList<T> list2)
        {
            TestList<T> result = new TestList<T>();

            if (list1.Count != list2.Count)
            {
                throw new InvalidOperationException("Lists are different sizes!");
            }
            else
            {
                for(int i = 0; i < list1.Count; i++)
                {
                    result.Add((dynamic)list1[i] + (dynamic)list2[i]);
                }
            }

            return result;
        }

        public override string ToString()
        {
            string tempString = string.Empty;

            for(int i=0; i<this._count; i++)
            {
                if(i < this._count - 1)
                {
                    tempString += this._items[i] + ", ";
                }
                else
                {
                    tempString += this._items[i];
                }
            }

            return tempString;
            //return string.Join(", ", this._items);
        }
    }
}
