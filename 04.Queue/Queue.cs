using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Datastructure
{
    public class Queue<T>
    {
        private const int DefaultCapacity = 4;

        private T[] array;
        private int head;
        private int tail;
        private int count;


        public Queue()
        {
            array = new T[DefaultCapacity];
            head = 0;
            tail = 0;
            count = 0;
        }

        public void Enqueue(T item)
        {
            if (isFull())
            {
                Grow();
            }
            array[tail] = item;

            tail++;
            if (tail == array.Length)
            {
                tail = 0;
            }

            count++;
        }

        public T Dequeue()
        {
            if (count == 0)
                throw new InvalidOperationException();

            T item = array[head];
            head++;
            if (head == array.Length)
            {
                head = 0;
            }

            count--;
            return item;

        }

        public bool isFull()
        {
            if (head > tail)
            {
                return head == tail + 1;
            }
            else
            {
                return head == 0 && tail == array.Length - 1;
            }
        }

        private void Grow()
        {
            T[] newArray = new T[array.Length * 2];
            if (head < tail)
            {
                Array.Copy(array, head, newArray, 0, tail);
            }
            else
            {
                Array.Copy(array, head, newArray, 0, array.Length - head);
                Array.Copy(array, 0, newArray, array.Length - head, tail);
            }
            array = newArray;
            tail = count;
            head = 0;
        }
    }
}
