using System;

namespace testoperator
{
    class CBox
    {
        private double _length;
        private double _breadth;
        private double _height;

        public CBox(double length, double breadth, double height)
        {
            _length = length;
            _breadth = breadth;
            _height = height;
        }

        public void display()
        {
            Console.WriteLine("length: {0}, breadth: {1}, height: {2}", _length, _breadth, _height);
        }

        public static CBox operator+ (CBox box1, CBox box2)
        {
            return new CBox(box1._length + box2._length, box1._breadth + box2._breadth, box1._height + box2._height);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CBox box1 = new CBox(1.23, 2.34, 3.45);
            CBox box2 = new CBox(3.21, 4.32, 5.43);
            CBox box3 = box1 + box2;
            box3.display();
            Console.ReadLine();
        }
    }
}
