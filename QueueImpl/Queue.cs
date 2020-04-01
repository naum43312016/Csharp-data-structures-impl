using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpDataStructures.QueueImpl
{
    class Queue<T>
    {
        private int size;
        private Node first;
        private Node last;
        public Queue()
        {
            this.size = 0;
        }

        private class Node
        {
            public T elem;
            public Node next;

            public Node(T elem)
            {
                this.elem = elem;
            }
        }


        public void add(T elem)
        {
            if (first == null)
            {
                first = new Node(elem);
            }
            else if (last == null)
            {
                last = new Node(elem);
                first.next = last;
            }
            else
            {
                Node n = new Node(elem);
                last.next = n;
                last = n;
            }
            size++;
        }

        public T poll()
        {
            if (first == null) return default(T);
            T elem = first.elem;
            first = first.next;
            if (first == last)
            {
                last = null;
            }
            size--;
            return elem;
        }

        public T peek()
        {
            if (first == null) return default(T);
            return first.elem;
        }

        public int length()
        {
            return this.size;
        }

    }
}
