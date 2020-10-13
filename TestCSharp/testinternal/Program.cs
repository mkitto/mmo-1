using System;

namespace testinternal
{
    class Rectangle
    {
        internal double length;
        internal double width;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle();
            rect.length = 1.23;
            rect.width = 2.34;
            Console.WriteLine(rect.length);
            Console.WriteLine(rect.width);
            Console.ReadLine();
        }
    }
}
