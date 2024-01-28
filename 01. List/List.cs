using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Datastructure
{
    public class List<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;
        private int count;

        public List()
        {
            items = new T[DefaultCapacity];
            count = 0;
        }

        public List(int capacity)
        {
            items = new T[capacity];
            count = 0;
        }

        public int Capacity { get { return items.Length; } }
        public int Count { get { return count; } }

        public bool isFull { get { return count == items.Length; } }

        public T this[int index]
        {
            get
            {
                return items[index];
            }

            set
            {
                items[index] = value;
            }


        }




        public void Add(T item)
        {
            if (count == items.Length)// 가득 차 있을 때 (==isFull)
            {
                Grow();
                items[count++] = item;

            }

        }

        public void Insert(int index, T item)
        {
            // 예외처리 필요 : 크기를 벗어나게 하는 경우 중간에 끼워넣는것을 불가능
            if (index < 0 || index > count)
                throw new ArgumentNullException("index");


            if (isFull)
                Grow();

            Array.Copy(items, index, items, index + 1, count - index);

            items[index] = item;
            count++;


        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            else
            {
                return false;
            }
        }



        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentException("index");

            count--;
            Array.Copy(items, index, items, index + 1, count - index);

        }
        public int IndexOf(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (item.Equals(items[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        private void Grow()
        {
            //2.새로운 더 큰 배열 생성
            T[] newItems = new T[items.Length * 2]; //2.새로운 더 큰 배열 생성
            Array.Copy(items, newItems, items.Length);   //3.새로운 배열에 기존의 데이터 복사

            /*== for(int i=0; i<items.Length; i++)
             {
                 newItems[i] = items[i];
             }                             */

            items = newItems;  //4. 기본 배열 대신 새로운 배열을 사용

        }


    }



}
