using System;

namespace testindexer
{
    class CIndexName
    {
        public static int size = 10;
        private string[] nameList = new string[size];

        public string this[int index]
        {
            get
            {
                string tmp;
                if (index >= 0 && index <= size - 1)
                {
                    tmp = nameList[index];
                }
                else
                {
                    tmp = "";
                }
                return tmp;
            }

            set
            {
                if (index >= 0 && index <= size - 1)
                {
                    nameList[index] = value;
                }
            }
        }

        public int this[string name]
        {
            get
            {
                int i = 0;
                for (; i < size; ++i)
                {
                    if (name == nameList[i])
                        return i;
                }
                return i;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CIndexName names = new CIndexName();
            names[0] = "JoJo";
            names[1] = "Dio";
            names[2] = "Van";

            for (int i = 0; i < CIndexName.size; ++i)
            {
                Console.WriteLine(names[i]);
            }
            Console.WriteLine("Dio: {0}", names["Dio"]);
            Console.WriteLine("Kakaxi: {0}", names["Kakaxi"]);
            Console.ReadLine();
        }
    }
}
