using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpDataStructures.Graph
{
    class Graph
    {
        int V;
        LinkedList<int>[] adjListArray;
        public Graph(int V)
        {
            this.V = V;

            adjListArray = new LinkedList<int>[V];

            for (int i = 0; i < V; i++)
            {
                adjListArray[i] = new LinkedList<int>();
            }
        }

        public void addEdge(Graph graph, int src, int dest)
        {
            
            graph.adjListArray[src].AddLast(dest);

            
            graph.adjListArray[dest].AddLast(src);
        }

        public void printGraph(Graph graph)
        {
            for (int v = 0; v < graph.V; v++)
            {
                Console.WriteLine("Adjacency list of vertex " + v);
                Console.WriteLine("Head");
                foreach (int pCrawl in graph.adjListArray[v])
                {
                    Console.WriteLine(" -> " + pCrawl);
                }
                Console.WriteLine("\n");
            }
        }

    }
}
