//#define MY_GENERIC_ARRAY
//#define GENERIC_METHOD
#define GENERIC_DELEGATE
using System;

namespace testgeneric
{
    class MyGenericArray<T>
    {
        private T[] _array;
        public MyGenericArray(int size)
        {
            _array = new T[size + 1];
        }

        public T getItem(int index)
        {
            return _array[index];
        }

        public void setItem(int index, T value)
        {
            _array[index] = value;
        }
    }

    class Program
    {
        static void Swap<T>(ref T l, ref T r)
        {
            T temp;
            temp = l;
            l = r;
            r = temp;
        }

        delegate void printDelegate<T>(T message);

        public static void printInt(int message)
        {
            Console.WriteLine("Int: {0}", message);
        }

        public static void printString(string message)
        {
            Console.WriteLine("String: {0}", message);
        }

        static void Main(string[] args)
        {
#if MY_GENERIC_ARRAY
            MyGenericArray<int> array1 = new MyGenericArray<int>(5);
            for (int i = 0; i < 5; ++i)
            {
                array1.setItem(i, i * 5);
            }

            for (int i = 0; i < 5; ++i)
            {
                Console.Write(array1.getItem(i) + " ");
            }
            Console.WriteLine();

            MyGenericArray<char> array2 = new MyGenericArray<char>(5);
            for (int i = 0; i < 5; ++i)
            {
                array2.setItem(i, (char)(i + 97));
            }

            for (int i = 0; i < 5; ++i)
            {
                Console.Write(array2.getItem(i) + " ");
            }
            Console.WriteLine();
#endif
#if GENERIC_METHOD
            int a, b;
            char c, d;
            a = 10;
            b = 20;
            c = 'R';
            d = 'T';

            Console.WriteLine("a: {0}, b: {1}, c: {2}, d: {3}", a, b, c, d);
            Swap<int>(ref a, ref b);
            Swap<char>(ref c, ref d);
            Console.WriteLine("a: {0}, b: {1}, c: {2}, d: {3}", a, b, c, d);
            Console.ReadLine();
#endif
#if GENERIC_DELEGATE
            printDelegate<int> pd1 = new printDelegate<int>(printInt);
            printDelegate<string> pd2 = new printDelegate<string>(printString);
            pd1(77777);
            pd2("七七七七七");
            Console.ReadLine();
#endif
        }
    }
}
