using System;

namespace testnullable
{
    class Program
    {
        

        static void Main(string[] args)
        {
            int a = 25;
            int? b = new int?();

            int num;
            num = b ?? 234;
            Console.WriteLine("a: {0}, b: {1}, num: {2}", a, b, num);
            Console.ReadLine();
        }
    }
}
