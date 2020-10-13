using System;

namespace testinherit
{
    class CParent
    {
        public virtual void func()
        {
            Console.WriteLine("CParent...");
        }
    }

    public interface CInter
    {
        void Print();
    }

    class CChild1: CParent, CInter
    {
        public override void func()
        {
            Console.WriteLine("CChild1...");
        }

        public void Print()
        {
            Console.WriteLine("Print...");
        }
    }

    class CChild2:CParent
    {
        public new void func()
        {
            Console.WriteLine("CChild2...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            // override是重写，即将基类的方法在派生类里直接抹去重新写，故而调用的方法就是子类方法；
            // 而new只是将基类的方法在派生类里隐藏起来，故而调用的仍旧是基类方法
            CParent obj1 = new CChild1();
            obj1.func();

            CParent obj2 = new CChild2();
            obj2.func();

            CChild1 obj3 = new CChild1();
            obj3.Print();

            Console.ReadLine();
        }
    }
}
