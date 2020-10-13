using System;

namespace testdatatype
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(sizeof(int));

            object obj;
            obj = 100;
            Console.WriteLine(obj);

            string str = @"1\n\t";
            // string str = "1\n\t";
            Console.WriteLine(str);

            unsafe
            {
                int obj1 = 200;
                int* obj2 = &obj1;
                *obj2 = 300;
                Console.WriteLine(obj1);
            }
            
            Console.ReadLine();
        }
    }
}
