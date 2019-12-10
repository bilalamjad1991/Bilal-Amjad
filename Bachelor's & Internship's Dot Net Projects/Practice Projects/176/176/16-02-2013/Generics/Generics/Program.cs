using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> obj = new List<string>();
            obj.Add("12");
            Console.WriteLine(obj.Count());
            obj.Add("12");
            Console.WriteLine(obj.Count());
            string test = "This is string";
            obj.Add(test);
            Console.WriteLine(obj[2]);
            Console.WriteLine(obj.Count());
            obj.Add("12");
            Console.WriteLine(obj.Count());
            obj.RemoveAt(2);
            Console.WriteLine(obj.Count());
            //ArrayList obj2 = new ArrayList();
            //obj2.Add(12);


            //LinkedList<>
            //LinkedList<int> intLinkedList = new LinkedList<int>();
            //LinkedListNode<int> node1 = new LinkedListNode<int>(15);
            //intLinkedList.AddFirst(node1);
            //LinkedListNode<int> node2 = new LinkedListNode<int>(15);
            //intLinkedList.AddFirst(node2);
            //LinkedListNode<int> node3 = new LinkedListNode<int>(15);
            //intLinkedList.AddFirst(node3);

            //intLinkedList.AddAfter(node2, 12);

            

            Stack<string> st = new Stack<string>();
            st.Push("First");
            st.Push("Second");

            string last =  st.Pop();
            Console.WriteLine(last);

            Queue<string> qu = new Queue<string>();
            qu.Enqueue("First");
            qu.Enqueue("Second");

            string lastq = qu.Dequeue();
            Console.WriteLine(lastq);


            SortedList<int, int> sl = new SortedList<int, int>();
            sl.Add(12, 12);
            sl.Add(10, 10);

            // todo: dO IT YOURSELF
            //SortedList<string, int> sl2 = new SortedList<string, int>();
            //sl2.Add("xyz", 10);
            //sl2.Add("12", 12);
            //sl2.Add("ab", 10);
            //sl2.Add("12ab", 10);
            //sl2.Add("ab12", 10);
            //sl2.Add("XYZ12", 10);
            // sorting criteria?


            // Explore Dictionary<>


            
        }
    }
}
