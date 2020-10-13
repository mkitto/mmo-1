using System;

namespace teststring
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "hello ";
            string str2 = "c sharp";

            string str3 = str1 + str2;
            Console.WriteLine("str3: {0}", str3);

            char[] str4 = { 'k', 'o', 'n', 'o', 'd', 'i', 'o', 'd', 'a' };
            string str5 = new string(str4);
            Console.WriteLine("str5: {0}", str5);

            string[] str6 = { "ko", "no", "dio", "da" };
            string str7 = String.Join(" ", str6);
            Console.WriteLine("str7: {0}", str7);

            DateTime dt = new DateTime(2020, 10, 7, 3, 56, 1);
            string str8 = String.Format("{0:t}, {0:D}", dt);  // t: time, D: Date
            Console.WriteLine("str8: {0}", str8);

            if(String.Compare(str3, str5) == 0)
            {
                Console.WriteLine("equal");
            }
            else
            {
                Console.WriteLine("not equal");
            }

            Console.WriteLine(str5.Contains("dio"));

            Console.ReadLine();
        }
    }
}
