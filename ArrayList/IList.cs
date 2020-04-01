using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpDataStructures.ArrayList
{
    interface IList<T>
    {
        public int length();
        public bool add(T elem);
        public bool add(int index, T elem);
        public bool set(int index, T elem);
        public T get(int index);
        public bool isEmpty();
        public int indexOf(T elem);
        public bool contains(T elem);
        public T remove(int index);
        public T remove(T elem);

    }
}
