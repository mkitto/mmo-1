using System;

namespace testmethod
{
    class Program
    {
        //public void swap(int x, int y)
        //{
        //    int temp;
        //    temp = x;
        //    x = y;
        //    y = temp;
        //}

        //public void swap(out int x,out int y)
        //{
        //    int temp = 100;
        //    x = temp;
        //    y = temp;
        //}

        public void swap(ref int x, ref int y)
        {
            //int temp;
            //temp = x;
            //x = y;
            //y = temp;
            x += y;
            y = x - y;
            x = x - y;
        }

        static void Main(string[] args)
        {
            Program prog = new Program();
            int a = 777;
            int b = 888;
            Console.WriteLine("before   a: {0}, b: {1}", a, b);
            //prog.swap(a, b);
            //prog.swap(out a, out b);
            prog.swap(ref a, ref b);
            Console.WriteLine("after   a: {0}, b: {1}", a, b);
            Console.ReadLine();
        }
    }
}
