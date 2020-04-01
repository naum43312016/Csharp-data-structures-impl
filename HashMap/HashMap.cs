using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpDataStructures.HashMap
{
    class HashMap<K,V>
    {
        private Node[] table;
        private int size;
        private static int INITIAL_CAPACITY = 16;
        private static int MAX_SIZE = 1 << 30;


        public HashMap()
        {
            this.size = 0;
            this.table = new Node[INITIAL_CAPACITY];
        }

        private class Node
        {
            public int hash;
            public K key;
            public V val;
            public Node next;

            public Node(K key, V val, int hash)
            {
                this.hash = hash;
                this.key = key;
                this.val = val;
            }
        }

        public void put(K key, V val)
        {
            int hash = getHash(key);
            int cell = getCell(hash);
            Node n = new Node(key, val, hash);
            Node node = table[cell];
            if (node == null)
            {
                table[cell] = n;
                size++;
                return;
            }
            while (node.next != null)
            {
                if (node.key.Equals(n.key))
                {
                    node.val = n.val;
                    return;
                }
                node = node.next;
            }
            if (node.key.Equals(n.key))
            {
                node.val = n.val;
                size++;
                return;
            }
            node.next = n;
            size++;
        }

        public V get(K key)
        {
            int hash = getHash(key);
            int cell = getCell(hash);
            Node node = table[cell];
            while (node != null)
            {
                if (node.key.Equals(key))
                {
                    return (V)node.val;
                }
                node = node.next;
            }
            return default(V);
        }



        public bool containsKey(K key)
        {
            int hash = getHash(key);
            int cell = getCell(hash);
            Node node = table[cell];
            while (node != null)
            {
                if (node.key.Equals(key))
                {
                    return true;
                }
                node = node.next;
            }
            return false;
        }


        public bool remove(K key)
        {
            int hash = getHash(key);
            int cell = getCell(hash);
            Node node = table[cell];
            if (node == null) return false;
            if (node.key.Equals(key))
            {
                table[cell] = node.next;
                return true;
            }
            while (node.next != null)
            {
                if (node.next.key.Equals(key))
                {
                    node.next = node.next.next;
                    return true;
                }
                node = node.next;
            }
            return false;
        }


        private int getHash(K key)
        {
            return key.GetHashCode();
        }
        private int getCell(int hash)
        {
            return hash % table.Length;
        }
        public bool isEmpty()
        {
            return this.size == 0;
        }
        public int length()
        {
            return this.size;
        }


    }

}
