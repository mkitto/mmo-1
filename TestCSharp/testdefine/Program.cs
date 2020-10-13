#define DEBUG  // 实际上就是DEBUG模式，可以切换Release测试
#define VC_V10

using System;

namespace testdefine
{
#pragma warning disable 169    // 取消编号 169 的警告（字段未使用的警告）
    class MyClass
    {
        int neverUsedField;       // 编译整个 MyClass 类时不会发出警告
    }
#pragma warning restore 169   // 恢复编号 169 的警告

    class Program
    {
        static void Main(string[] args)
        {
#if (DEBUG && !VC_V10)
            Console.WriteLine("DEBUG is define");
//#error "DEBUG is define"
//#warning "VC_V10 is define"
#elif (!DEBUG && VC_V10)
            //Console.WriteLine("VC_V10 is define");
#elif (DEBUG && VC_V10)
            Console.WriteLine("DEBUG and VC_V10 is define");
#else
            Console.WriteLine("DEBUG and VC_V10 is  not define");
#endif
        Console.ReadLine();
        }
    }
}
