using System;

namespace testinterface
{
    interface IPrint1
    {
        void Print1();
    }

    interface IPrint2: IPrint1
    {
        void Print2();
        void Print();
    }

    interface IPrint3
    {
        void Print();
    }

    class CTest: IPrint2, IPrint3
    {
        public void Print1()
        {
            Console.WriteLine("Print1......");
        }
        public void Print2()
        {
            Console.WriteLine("Print2......");
        }

        void IPrint2.Print()
        {
            Console.WriteLine("Print2.Print......");
        }

        void IPrint3.Print()
        {
            Console.WriteLine("Print3.Print......");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CTest obj = new CTest();
            obj.Print1();
            obj.Print2();
            /*
             如果两个接口中有相同的方法名，那么同时实现这两个接口的类，
            就会出现不确定的情形，在编写方法时，也不知道实现哪个接口的方法了,
            为解决这一问题，C#提供了显示接口实现技术，就是在方法名前加接口名称，
            用接口名称来限定成员
             */
            IPrint2 obj2 = new CTest();
            obj2.Print();

            IPrint3 obj3 = new CTest();
            obj3.Print();
            Console.ReadLine();
        }
    }
}
