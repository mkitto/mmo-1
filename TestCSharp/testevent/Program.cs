using System;
using System.IO;

namespace testevent
{
    class Program
    {
        // 发布器类
        public class CEventTest
        {
            private int _value;
            public delegate void printStreamHander(string str);
            public event printStreamHander printStream;

            protected virtual void OnNumChanged(string message)
            {
                if (printStream != null)
                {
                    printStream(message);
                }
                else
                {
                    Console.WriteLine("event not fire");
                    Console.ReadKey();
                }
            }

            public void SetValue(int n)
            {
                if (_value != n)
                {
                    _value = n;
                    OnNumChanged(String.Format("num change to {0}", _value));
                }
                else
                {
                    OnNumChanged("the num is not change");
                }
            }
        }

        // 订阅器类
        public class CSubscribEvent
        {
            FileStream fs;
            StreamWriter sw;
            public CSubscribEvent(string fileName)
            {
                fs = new FileStream(fileName, FileMode.Append, FileAccess.Write);
                sw = new StreamWriter(fs);
            }

            public void logger(string info)
            {
                sw.WriteLine(info);
            }

            public void Close()
            {
                sw.Close();
                fs.Close();
            }
        }

        public static void printLogger(string info)
        {
            Console.WriteLine("info: {0}", info);
        }

        static void Main(string[] args)
        {
            CEventTest obj1 = new CEventTest();
            obj1.SetValue(7);
            CSubscribEvent obj2 = new CSubscribEvent("log.txt");
            obj1.printStream += new CEventTest.printStreamHander(obj2.logger);  // 注册
            obj1.printStream += new CEventTest.printStreamHander(printLogger);  // 注册
            //obj1.printStreamHander = new CEventTest.printStreamHander(obj2.logger);   // 不能这么用，是类型
            obj1.SetValue(7);
            obj1.SetValue(7);
            obj1.SetValue(8);
            obj2.Close();
            Console.ReadLine();
        }
    }

    
}
