using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testclass
{
    class Box
    {
        private double _length;
        private double _breadth;
        private double _height;
        public static int count;

        public Box(double length, double breadth, double height)
        {
            _length = length;
            _breadth = breadth;
            _height = height;
            count++;
            Console.WriteLine("对象已创建: {0}", count);
        }

        ~Box()
        {
            Console.WriteLine("对象已删除");
        }

        public double getVolume()
        {
            return _length * _breadth * _height;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Box box1 = new Box(2.22, 3.33, 50);
            Box box2 = new Box(2.22, 3.33, 50);
            Console.ReadLine();
        }
    }
}
