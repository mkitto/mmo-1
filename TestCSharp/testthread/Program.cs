//#define CREATE
//#define MANAGE
#define ABORT

using System;
using System.Threading;

namespace testthread
{
    class Program
    {
#if CREATE
        public static void CallToChildThread()
        {
            Console.WriteLine("Child thread starts");
        }
#endif
#if MANAGE
        public static void CallToChildThread()
        {
            // 线程暂停5000毫秒
            Thread.Sleep(5000);
            Console.WriteLine("Child thread resumes");
        }
#endif
#if ABORT
        public static void CallToChildThread()
        {
            try
            {
                Console.WriteLine("Child thread starts");
                for (int counter = 0; counter <= 10; ++counter)
                {
                    //Thread.Sleep(100);
                    Thread.Sleep(500);
                    Console.WriteLine(counter);
                }
                Console.WriteLine("Child thread complete");
            }
            catch(ThreadAbortException e)
            {
                // 这个异常不能被捕获
                Console.WriteLine("Thread Abort Exception");
            }
            finally
            {
                Console.WriteLine("Couldn't catch the Thread Exception");
            }
        }
#endif

        static void Main(string[] args)
        {
#if CREATE
            /*==========创建线程==========*/
            ThreadStart childref = new ThreadStart(CallToChildThread);
            Console.WriteLine("In Main: Creating the Child thread");
            Thread childThread = new Thread(childref);
            childThread.Start();
            Console.ReadLine();
#endif

#if MANAGE
            ThreadStart childref = new ThreadStart(CallToChildThread);
            Console.WriteLine("In Main: Creating the Child thread");
            Thread childThread = new Thread(childref);
            childThread.Start();
            Console.ReadLine();
#endif

#if ABORT
            ThreadStart childref = new ThreadStart(CallToChildThread);
            Console.WriteLine("In Main: Creating the Child thread");
            Thread childThread = new Thread(childref);
            childThread.Start();
            // 停止主线程一段事件
            Thread.Sleep(2000);
            // 现在中止子线程
            Console.WriteLine("In Main: Aborting the Child thread");

            //childThread.Abort();  // .NET Core 不支持此成员
            childThread.Interrupt();

            Console.ReadLine();
#endif
        }
    }
}
