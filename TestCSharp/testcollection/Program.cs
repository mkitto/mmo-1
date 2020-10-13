//#define ARRAY_LIST
//#define HASH_TABLE
//#define SORTED_LIST
//#define STACK
//#define QUEUE
#define BIT_ARRAY
using System;
using System.Collections;

namespace testcollection
{
    class Program
    {
        static void Main(string[] args)
        {
#if ARRAY_LIST
            ArrayList al = new ArrayList();
            al.Add(2333);
            al.Add(7777);
            al.Add(6666);
            al.Add(12306);

            Console.WriteLine("Capacity: {0}", al.Capacity);
            Console.WriteLine("Count: {0}", al.Count);

            Console.Write("Content: ");
            foreach(int i in al)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Console.Write("Sorted Content: ");
            al.Sort();
            foreach (int i in al)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.ReadLine();
#endif
#if HASH_TABLE
            Hashtable ht = new Hashtable();
            ht.Add("001", "JoJo");
            ht.Add("002", "Dio");
            ht.Add("003", "Van");

            if (ht.ContainsValue("Kris Wu"))
            {
                Console.WriteLine("The boy is alread exist");
            }
            else
            {
                ht.Add("004", "Kris Wu");
            }

            ICollection key = ht.Keys;
            foreach(string k in key)
            {
                Console.WriteLine(k + ": " + ht[k]);
            }
            Console.ReadLine();
#endif
#if SORTED_LIST
            SortedList sl = new SortedList();
            sl.Add("001", "JoJo");
            sl.Add("002", "Dio");
            sl.Add("003", "Van");

            if (sl.ContainsValue("Kris Wu"))
            {
                Console.WriteLine("The boy is alread exist");
            }
            else
            {
                sl.Add("004", "Kris Wu");
            }
            ICollection key = sl.Keys;
            foreach (string k in key)
            {
                Console.WriteLine(k + ": " + sl[k]);
            }
            Console.ReadLine();
#endif
#if STACK
            Stack st = new Stack();
            st.Push("JoJo");
            st.Push("Dio");
            st.Push("Van");
            st.Push("Kris Wu");
            Console.WriteLine("Count: {0}", st.Count);
            
            foreach(string s in st)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("Peek: {0}", st.Peek());
            st.Pop();

            while (st.Count > 0)
            {
                Console.WriteLine("Pop: {0}", st.Pop());
            }
            Console.ReadLine();
#endif
#if QUEUE
            Queue q = new Queue();
            q.Enqueue("JoJo");
            q.Enqueue("Dio");
            q.Enqueue("Van");
            q.Enqueue("Kris Wu");

            foreach(string s in q)
            {
                Console.WriteLine(s);
            }

            string str = (string)q.Dequeue();
            Console.WriteLine("Dequeue: {0}", str);
            Console.ReadLine();
#endif
#if BIT_ARRAY
            BitArray ba1 = new BitArray(8);
            BitArray ba2 = new BitArray(8);
            byte[] a = { 4 };
            byte[] b = { 8 };
            ba1 = new BitArray(a);
            ba2 = new BitArray(b);
            for (int i = 0; i < ba1.Count; ++i)
            {
                Console.Write("{0, -6}", ba1[i]);  //“{v,w}”中的”v”表示参数下标，”w”表示输出长度。
            }

            for (int i = 0; i < ba2.Count; ++i)
            {
                Console.Write("{0, -6}", ba2[i]);
            }

            BitArray ba3 = ba1.Or(ba2);
            for (int i = 0; i < ba3.Count; ++i)
            {
                Console.Write("{0, -6}", ba3[i]);
            }
            Console.WriteLine();
            Console.ReadLine();
#endif

        }
    }
}
