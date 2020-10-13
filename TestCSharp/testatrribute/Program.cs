//#undef DEBUG
using System;
using System.Diagnostics;

namespace testatrribute
{
    
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    class MyAttribute: System.Attribute
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
    { }

    class Program
    {
        [Conditional("DEBUG")]
        static void print()
        {
            Console.WriteLine("Test Conditional...");
        }

        //[Obsolete("Don't use OldMethod, use NewMethod instead", true)]
        [Obsolete("Don't use OldMethod, use NewMethod instead", false)]
        static void oldMethod()
        {
            Console.WriteLine("old method...");
        }
        static void Main(string[] args)
        {
            print();
            oldMethod();

            //Type t = typeof(CTest);
            System.Reflection.MemberInfo t = typeof(CTest);
            object[] something = t.GetCustomAttributes(typeof(MyAttribute), true);
            //var something = t.GetCustomAttributes(typeof(MyAttribute), true);
            foreach (MyAttribute each in something)
            {
                Console.WriteLine("Attribute: {0}", each);
                Console.WriteLine("Name: {0}", each.Name);
                Console.WriteLine("Data: {0}", each.Data);
            }

            Console.ReadLine();
        }
    }
}
