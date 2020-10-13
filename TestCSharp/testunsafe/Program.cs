using System;

namespace testunsafe
{
    class Program
    {
        public unsafe void Swap(int* p, int* q)
        {
            int temp = *p;
            *p = *q;
            *q = temp;
        }

        static unsafe void Main(string[] args)
        {
            Program obj = new Program();
            int var1 = 10;
            int var2 = 20;
            int* x = &var1;
            int* y = &var2;

            Console.WriteLine("Before Swap: var1: {0}, var2: {1}, x: {2}, y: {3}", var1, var2, (int)x, (int)y);
            obj.Swap(x, y);

            Console.WriteLine("After Swap: var1: {0}, var2: {1}, x: {2}, y: {3}", var1, var2, (int)x, (int)y);
            Console.ReadLine();
        }
    }
}
