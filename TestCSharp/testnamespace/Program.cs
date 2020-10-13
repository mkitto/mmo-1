using System;
using namespace1.namespace2;

namespace namespace1
{
    namespace namespace2
    {
        class CTest
        {
            public void print()
            {
                Console.WriteLine("print......");
            }
        }
    }
}

namespace testnamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            //namespace1.namespace2.CTest obj = new namespace1.namespace2.CTest();
            CTest obj = new CTest();
            obj.print();
            Console.ReadLine();
        }
    }
}
