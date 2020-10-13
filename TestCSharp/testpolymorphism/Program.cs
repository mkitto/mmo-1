using System;

namespace testpolymorphism
{
    abstract class CShape
    {
        public int a;
        public static int b;
        abstract public void draw();
        public void test()
        {
            Console.WriteLine("test......");
        }
    }

    class CRect: CShape
    {
        public override void draw()
        {
            b++;
            base.a = 7777;
            Console.WriteLine("CRect...{0} {1}", b, a);
        }

        public void print(int a, int b)
        {
            Console.WriteLine("a: {0}, b: {1}", a, b);
        }

        public void print(double a, double b)
        {
            Console.WriteLine("a: {0}, b: {1}", a, b);
        }

        public virtual void virPrint()
        {
            Console.WriteLine("virPrint...");
        }
    }

    class CTriangle: CShape
    {
        public override void draw()
        {
            Console.WriteLine("CTriangle...");
        }
    }

    class CMultiRect: CRect
    {
        public override void virPrint()
        {
            Console.WriteLine("CMultiRect...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CRect obj1 = new CRect();
            obj1.draw();
            obj1.test();
            CTriangle obj2 = new CTriangle();
            obj2.draw();
            CRect obj3 = new CMultiRect();
            obj3.virPrint();
            Console.ReadLine();
        }
    }
}
