using System;
using System.IO;

namespace testdelegate
{
    class Program
    {
        static FileStream fs;
        static StreamWriter sw;
        //委托声明
        public delegate void printString(string s);

        public static void writeToScreen(string str)
        {
            Console.WriteLine("The string is: {0}", str);
        }

        public static void writeToFile(string s)
        {
            fs = new FileStream("message.txt", FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs);
            sw.WriteLine(s);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        public static void sendString(printString ps)
        {
            ps("Hello World");
        }
        static void Main(string[] args)
        {
            // 创建委托实例
            printString ps1 = new printString(writeToScreen);
            printString ps2 = new printString(writeToFile);
            // 多播
            printString ps3 = ps1 + ps2;
            ps3("JoJo");
            sendString(ps3);
            Console.ReadLine();
        }
    }
}
