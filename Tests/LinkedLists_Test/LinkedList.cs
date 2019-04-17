using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists_Test
{
    /*
     * 1) La lista è vuota alla creazione
     * 2) Get(int index) : ritorna l'elemento presente a quell'indice
     * 3) Add(T item) : inserisce in fondo alla lista un elemento
     * 4) Insert(T item, int index) : inserisce un elemento in una posizione specifica
     * 5) Remove(T item) : rimuove l'elemento item dalla lista
     * 6) Count{get;} : tiene il conto totale degli elementi della lista
     * 
     */

    class LinkedList<T>
    {
        public int Count { get; private set; }

        private Node _firstNode;
        
        public T Get(int index)
        {
            Node node = GetNode(index);

            if (node == null) {
                throw new IndexOutOfRangeException($"There is no element in position {index}.");
            }

            return node.Element;
        }

        public Node GetNode(int index)
        {
            if (index < -1 ) {
                throw new IndexOutOfRangeException($"Can't look for negative indexes: {index}.");
            }

            Node node = _firstNode;

            int indexer = -1;
            while(true) {
                if (indexer == index) {
                    return node;
                }
                if (node == null) {
                    return node;
                }
                node = node.NextNode;
                indexer++;
            }
        }

        public void Add(T item)
        {
            Node node = new Node(item);
            Node lastNode = GetNode(Count -1);

            if (lastNode == null) {
                lastNode = node;
            }
            else {
                lastNode.NextNode = node;
            }                      

            Count++;
        }

        public void Insert(T item, int index)
        {
            if (index > Count) {
                throw new IndexOutOfRangeException("Impossible to insert in this position.");
            }

            Node iNode = GetNode(index);

            Count++;
        }

        public void Remove(T item)
        {

        }

        public class Node
        {
            public Node(T item)
            {
                Element = item;
            }

            public Node NextNode { get; set; }
            public T Element { get; set; }
        }
    }
}
