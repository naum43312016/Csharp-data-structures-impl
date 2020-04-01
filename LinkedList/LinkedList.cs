using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpDataStructures.LinkedList
{
    class LinkedList<T>
    {
        private Node first;
        private Node last;
        private int size;

        public LinkedList()
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

        public bool add(T elem)
        {
            if (first == null)
            {
                first = new Node(elem);
                size++;
                return true;
            }
            else if (last == null)
            {
                last = new Node(elem);
                first.next = last;
                size++;
                return true;
            }
            else
            {
                Node node = new Node(elem);
                last.next = node;
                last = node;
                size++;
                return true;
            }
        }

        public int length()
        {
            return this.size;
        }

        
        public bool isEmpty()
        {
            return size == 0;
        }

        public bool contains(T elem)
        {
            if (size < 1) return false;
            Node node = first;
            while (node != null)
            {
                if (node.elem.Equals(elem))
                {
                    return true;
                }
                node = node.next;
            }
            return false;
        }

        public T get(int index)
        {
            if (size < 1) throw new Exception("Empty List");
            if (index >= size) throw new Exception();
            if (index == size - 1) return getLast();
            Node node = first;
            int i = 0;
            while (i != index)
            {
                i++;
                node = node.next;
            }


            return node.elem;
        }
        public T getFirst()
        {
            if (first == null) return default(T);
            return first.elem;
        }
        public T getLast()
        {
            if (last == null)
            {
                if (first != null)
                {
                    return first.elem;
                }
                else
                {
                    return default(T);
                }
            }
            return last.elem;
        }


        public bool remove(T elem)
        {
            if (size < 1 || first == null) throw new Exception("Empty List");
            if (first.elem.Equals(elem))
            {
                Node n = first.next;
                first = n;
                size--;
            }
            Node node = first;
            while (node.next != null)
            {
                if (node.next.elem.Equals(elem))
                {
                    if (node.next == last)
                    {
                        node.next = null;
                        last = node;
                        size--;
                        return true;
                    }
                    else
                    {
                        node.next = node.next.next;
                        size--;
                        return true;
                    }
                }
                node = node.next;
            }
            return false;
        }

        public bool remove(int index)
        {
            if (size < 1) throw new Exception("Empty List");
            if (index >= size) throw new Exception("IndexOutOfBoundsException");
            if (index == 0)
            {
                Node n = first.next;
                first = n;
                size--;
                return true;
            }
            if (index == size - 1)
            {
                return removeLast();
            }
            int i = 0;
            Node node = first;
            while (i < index - 1)
            {
                node = node.next;
                i++;
            }
            node.next = node.next.next;
            return true;
        }

        private bool removeLast()
        {
            int i = 0;
            Node node = first;
            while (i < size - 2)
            {
                node = node.next;
                i++;
            }
            size--;
            node.next = null;
            last = node;
            return true;
        }

    }
}
