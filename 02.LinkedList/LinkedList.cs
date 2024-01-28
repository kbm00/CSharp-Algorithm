using _02.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Datastructure
{
    internal class LinkedList<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int count;

        public LinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }


        public LinkedListNode<T> First { get { return head; } }
        public LinkedListNode<T> Last { get { return tail; } }
        public int Count { get { return count; } }


        public LinkedListNode<T> AddLast(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            if (tail != null)
            {
                InsertNodeToEmptyList(newNode);
            }
            else
            {
                InsertNodeAfter(tail, newNode);
            }
            return newNode;
        }


        public LinkedListNode<T> AddFirst(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            if (count == 0)
            {
                InsertNodeToEmptyList(newNode);
            }
            else
            {
                InsertNodeBefore(head, newNode);
            }

            return newNode;
        }


        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            InsertNodeBefore(node, newNode);
            return newNode;
        }

        public LinkedListNode<T> Find(T value)
        {

            return null;
        }


        private void InsertNodeBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            LinkedListNode<T> prevNode = node.prev;

            // 1. newNode의 prev를 node의 prev로
            newNode.prev = prevNode;

            // 2. newNode의 next를 node로
            newNode.next = node;

            // 3. node 앞의 노드의 유무

            if (node == head)  // 3-1. head를 newNode로
            {
                head = newNode;
            }
            else    // 3-2. node의 prev의 next를 newNode로
            {
                prevNode.next = newNode;
            }

            // 4 node의 prev를 next로
            node.prev = newNode;

            count++;

        }

        public void InsertNodeAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            newNode.prev = node;
            newNode.next = node.Next;

            if (node == tail)
            {
                tail = newNode;
            }
            else
            {
                node.next.prev = newNode;
            }

            node.next = newNode;

            count++;


        }

        private void InsertNodeToEmptyList(LinkedListNode<T> newNode)
        {
            if (count != 0)
                throw new InvalidOperationException();

            head = newNode;
            tail = newNode;
            count++;
        }
        public void Remove(T value)
        {

        }




        public void Remove(LinkedListNode<T> node)
        {
            RemoveNode(node);
        }

        public void RemoveFirtst()
        {
            RemoveNode(head);
        }

        public void RemoveLast()
        {
            RemoveNode(tail);
        }




        private void RemoveNode(LinkedListNode<T> node)
        {
            if (node == null)
                throw new ArgumentException("node");

            if (head == node)
                head = node.next;
            if (tail == node)
                tail = node.prev;

            if (node.prev != null)
                node.prev.next = node.next;
            if (node.next != null)
                node.next.prev = node.prev;

            count--;
        }



    }

    public class LinkedListNode<T>
    {
        private T value;

        public LinkedListNode<T> prev;
        public LinkedListNode<T> next;

        public LinkedListNode(T value)
        {
            this.value = value;
            this.prev = null;
            this.next = null;

        }

        public LinkedListNode(T value, LinkedListNode<T> prev, LinkedListNode<T> next)
        {
            this.value = value;
            this.prev = prev;
            this.next = next;
        }

        public LinkedListNode<T> Prev { get { return prev; } }
        public LinkedListNode<T> Next { get { return next; } }

        public T Value { get { return value; } }
    }


}
