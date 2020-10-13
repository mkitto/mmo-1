using System;

namespace testanonymous
{
    delegate int NumberChange(int n);
    class Program
    {
        static void Main(string[] args)
        {
            NumberChange nc = delegate (int n)
            {
                return n * n;
            };
            Console.WriteLine(nc(89));
            Console.ReadLine();
        }
    }
}
