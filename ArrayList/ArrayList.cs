using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CSharpDataStructures.ArrayList
{
    class ArrayList<T> : IList<T>, IEnumerable<T>
    {
        private T[] data;
        private int size;
        private const int DEFAULT_CAPACITY = 2;
        private const int MAX_ARRAY_SIZE = Int32.MaxValue - 5;

        public ArrayList()
        {
            this.size = 0;
            this.data = new T[DEFAULT_CAPACITY];
        }

        public ArrayList(int capacity)
        {
            if(capacity<0 || capacity > MAX_ARRAY_SIZE)
            {
                throw new Exception("Illegal Capacity");
            }
            this.size = 0;
            this.data = new T[capacity];
        }

        public int length()
        {
            return this.size;
        }

        public bool add(T elem)
        {
            if (size >= MAX_ARRAY_SIZE)
            {
                throw new Exception("OutOfMemoryError " + size);
            }
            if (size >= data.Length) increaseCapacity();
            data[size++] = elem;
            return true;
        }

        public void print()
        {
            for(int i = 0; i < size; i++)
            {
                Console.WriteLine(data[i]);
            }
        }

        public bool add(int index, T elem)
        {
            if (!lenghtValidation(index))
            {
                throw new Exception("IndexOutOfBoundsException " + index + " Size " + data.Length);
            }
            T[] newData = new T[data.Length + 1];
            int i = 0;
            int y = 0;
            for (; y < newData.Length; y++)
            {
                if (y == index)
                {
                    newData[index] = elem;
                    continue;
                }
                newData[y] = data[i];
                i++;
            }
            data = newData;
            size++;
            return true;
        }

        public bool set(int index, T elem)
        {
            if (!lenghtValidation(index))
            {
                throw new Exception("IndexOutOfBoundsException " + index);
            }
            data[index] = elem;
            return true;
        }

        public T get(int index)
        {
            if (index >= size || index<0)
            {
                throw new Exception("IndexOutOfBoundsException " + index);
            }
            return data[index];
        }

        public bool isEmpty()
        {
            if (size == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int indexOf(T elem)
        {
            if (elem == null)
            {
                for (int i = 0; i < size; i++)
                    if (data[i] == null)
                        return i;
            }
            else
            {
                for (int i = 0; i < size; i++)
                    if (elem.Equals(data[i]))
                        return i;
            }
            return -1;
        }

        public bool contains(T elem)
        {
            return indexOf(elem) >= 0;
        }

        public T remove(int index)
        {
            if (!lenghtValidation(index))
            {
                throw new Exception("IndexOutOfBoundsException " + index);
            }
            T[] newData = new T[data.Length - 1];
            int i = 0;
            int y = 0;
            for (; i < data.Length; i++)
            {
                if (i == index)
                {
                    continue;
                }
                newData[y] = data[i];
                y++;
            }
            size--;
            data = newData;
            T newValue = (T)data[index];
            return newValue;
        }

        public T remove(T elem)
        {
            return remove(indexOf(elem));
        }

        private void increaseCapacity()
        {
            int oldCapacity = data.Length;
            int newCapacity = oldCapacity + (oldCapacity >> 1);
            if (newCapacity > MAX_ARRAY_SIZE)
            {
                newCapacity = MAX_ARRAY_SIZE;
            }
            T[] arr = new T[newCapacity];
            Array.Copy(data, 0, arr, 0, oldCapacity);
            data = arr;
        }

        private bool lenghtValidation(int index)
        {
            if (index >= data.Length)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < size; i++)
            {
                yield return data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}