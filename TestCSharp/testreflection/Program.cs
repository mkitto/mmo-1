using System;
using System.Diagnostics;
using System.Reflection;

namespace testatrribute
{

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    class MyAttribute : System.Attribute
    {
        private string _name;
        private string _data;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                Name = value;
            }
        }

        public string Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        public MyAttribute(string name, string data)
        {
            _name = name;
            _data = data;
        }
    }

    [My("Van", "Deep Dark Fantastic")]
    [My("Dio", "Ko no dio da")]
    class CTest
    {
        [My("JoJo", "Mu da mu da")]
        public void Display()
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(CTest);
            //System.Reflection.MemberInfo t = typeof(CTest);
            object[] something = t.GetCustomAttributes(typeof(MyAttribute), true);
            //var something = t.GetCustomAttributes(typeof(MyAttribute), true);
            foreach (MyAttribute each in something)
            {
                Console.WriteLine("Attribute: {0}", each);
                Console.WriteLine("Name: {0}", each.Name);
                Console.WriteLine("Data: {0}", each.Data);
            }

            MethodInfo[] mi =  t.GetMethods();
            foreach(MethodInfo methodInfo in mi)
            {
                foreach(Attribute a in methodInfo.GetCustomAttributes(true))
                {
                    /*
                    解决：将(DeBugInfo)a 修改为 DeBugInfo dbi = a as DeBugInfo;
                    原因：
                    前者是一种强制转换类型，是一种将两个不同类型的值向上或者向下转换因此会报错。
                    后者，通过 object 声明对象，是用了装箱和取消装箱的概念，也就是说 object 可以看成是所有类型的父类，
                    因此 object 声明的对象可以转换成任意类型的值。
                    */
                    //MyAttribute obj = (MyAttribute)a;
                    MyAttribute obj = a as MyAttribute;
                    if (null != obj)
                    {
                        Console.WriteLine("Name: {0}", obj.Name);
                        Console.WriteLine("Method: {0}", methodInfo.Name);
                    }
                    
                }
                
            }

            Console.ReadLine();
        }
    }
}
