using System;

namespace testswitch
{
    class Program
    {
        static void Main(string[] args)
        {
            char oper;
            int a = 36;
            int b = 6;
            oper = Console.ReadLine()[0];
            switch(oper)
            {
                case '+':
                    Console.WriteLine(a + b);
                    break;
                case '-':
                    Console.WriteLine(a - b);
                    break;
                case '*':
                    Console.WriteLine(a * b);
                    break;
                case '/':
                    Console.WriteLine(a / b);
                    break;
                default:
                    Console.WriteLine("a: {0}, b: {1}", a, b);
                    break;
            }
            Console.ReadLine();
        }
    }
}
