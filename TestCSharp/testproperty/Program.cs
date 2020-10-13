using System;

namespace testproperty
{
    public abstract class CAbstract
    {
        public abstract string Name
        {
            set;
            get;
        }
    }

    class CTest: CAbstract
    {
        private string name = "N.A";
        private int num = 0;
        public static int count = 0;
        public override string Name
        {
            set
            {
                name = value;
                count++;
            }
            get
            {
                return name;
            }
        }

        public int Num
        {
            set
            {
                if (value > 0)
                {
                    num = value;
                }
                else
                {
                    throw new Exception("值的范围不合法");
                }
            }
            get
            {
                return num;
            }
        }

        public string ID { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CTest obj = new CTest();
            obj.Name = "JoJo";
            try
            {
                obj.Num = 2;
                obj.Num = -1;
                obj.Num = 3;
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }
            finally
            {
                Console.WriteLine("Num: {0}, count: {1}", obj.Num, CTest.count);
            }

            obj.ID = "sjska";
            Console.WriteLine("ID: {0}", obj.ID);
            Console.ReadLine();
        }
    }
}
