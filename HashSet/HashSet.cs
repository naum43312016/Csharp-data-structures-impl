using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpDataStructures.HashSet
{
    class HashSet<T>
    {
        private Node[] table = new Node[INITIAL_CAPACITY];
        private int size;
        private static int INITIAL_CAPACITY = 16;
        private static int MAXIMUM_CAPACITY = 1 << 30;
        public HashSet()
        {
            this.size = 0;
        }


        private class Node
        {
            public T val;
            public int hash;
            public Node next;

            public Node(T v, int h)
            {
                this.val = v;
                this.hash = h;
            }
            public bool equals(Node obj)
            {
                Node node = obj;
                if (this.val.Equals(node.val) && this.hash == node.hash)
                {
                    return true;
                }
                return false;
            }
        }

        public void put(T elem)
        {
            if (table.Length >= Int32.MaxValue - 1) throw new Exception("Out of memory");
            if (size >= table.Length - 1)
            {
                reHash();
            }
            int hash = getHash(elem);
            int cell = getCell(hash);
            Node node = new Node(elem, hash);
            put(node, cell);
            size++;
        }

        private void reHash()
        {
            Node[] newTable = new Node[table.Length * 2];
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != null)
                {
                    Node n = table[i];
                    while (n != null)
                    {
                        int hash = n.hash;
                        Node node = new Node(n.val, hash);
                        int cell = hash % newTable.Length;
                        if (newTable[cell] == null)
                        {
                            newTable[cell] = node;
                        }
                        else
                        {
                            Node t = newTable[cell];
                            while (t != null)
                            {
                                if (t.equals(node)) return;
                                t = t.next;
                            }
                            node.next = newTable[cell];
                            newTable[cell] = node;
                        }
                        n = n.next;
                    }
                }
            }
            table = newTable;
        }


        public bool contains(T elem)
        {
            int hash = getHash(elem);
            int cell = getCell(hash);
            Node n = table[cell];
            while (n != null)
            {
                if (elem.Equals(n.val) && hash == n.hash)
                {
                    return true;
                }
                n = n.next;
            }
            return false;
        }

        public bool remove(T elem)
        {
            int hash = getHash(elem);
            int cell = getCell(hash);
            Node n = table[cell];
            if (n != null)
            {
                if (elem.Equals(n.val) && hash == n.hash)
                {
                    table[cell] = n.next;
                    size--;
                    return true;
                }
            }
            while (n.next != null)
            {
                if (elem.Equals(n.next.val) && hash == n.next.hash)
                {
                    n.next = n.next.next;
                    size--;
                    return true;
                }
                n = n.next;
            }
            return false;
        }


        private void put(Node node, int cell)
        {
            if (table[cell] == null)
            {
                table[cell] = node;
            }
            else
            {
                Node t = table[cell];
                while (t != null)
                {
                    if (t.equals(node)) return;
                    t = t.next;
                }
                node.next = table[cell];
                table[cell] = node;
            }
        }


        private int getHash(T elem)
        {
            return elem.GetHashCode();
        }
        private int getCell(int hash)
        {
            return hash % table.Length;
        }


        public int length()
        {
            return this.size;
        }

        public bool isEmpty()
        {
            return size == 0;
        }


    }
}
