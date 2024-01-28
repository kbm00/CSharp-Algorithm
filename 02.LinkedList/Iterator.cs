using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LinkedList
{
    internal class Iterator
    {
        static void Main3()
        {
            List<int> list = new List<int>();
            LinkedList<int> linkedList = new LinkedList<int>();
            SortedSet<int> set = new SortedSet<int>();


            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
                linkedList.AddLast(i);
                set.Add(i);
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i]} ");
            }

            /*for(int i=0; i< Linkedlist.Count; i++)
            {
                Console.Write($"{linkedList[i] ");
            }X  */

            for (LinkedListNode<int> node = linkedList.First; node != null; node = node.Next)
            {
                Console.Write($"{node.Value} ");
            }

            foreach (int value in list)
            {
                Console.Write($"{value} ");
            }

            foreach (int value in linkedList)
            {
                Console.WriteLine($"{value} ");
            }

            foreach (int value in set)
            {
                Console.WriteLine($"{value} ");
            }
            Book book = new Book();
            foreach (string value in book)
            {
                Console.WriteLine($"{value} ");
            }
            foreach (int value in Func())
            {
                Console.WriteLine($"{value} ");
            }
        }


        public static IEnumerable<int> Func()
        {
            yield return 10;
            yield return 20;
            yield return 30;
            yield return 40;
            yield return 50;
        }


        public class Book : IEnumerable<string>
        {
            public string[] text;

            public IEnumerator<string> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }





    }


}
