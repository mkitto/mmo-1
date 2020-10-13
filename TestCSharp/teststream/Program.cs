using System;
using System.IO;

namespace teststream
{
    class Program
    {
        static void Main(string[] args)
        {
#if false
            FileStream fs = new FileStream("test.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            for (int i = 0; i < 20; ++i)
            {
                fs.WriteByte((byte)i);
            }
            fs.Position = 0;

            for (int i = 0; i < 20; ++i)
            {
                Console.Write(fs.ReadByte() + " ");
            }

            fs.Close();
#endif
#if false
            try
            {
                using (StreamReader sr = new StreamReader("jamaica.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("The file could not be read: ");
                Console.WriteLine(e.Message);
            }

#endif
            string[] names = new string[] { "zhang san", "li si" };
            using(StreamWriter sw = new StreamWriter("name.txt"))
            {
                foreach(string name in names)
                {
                    sw.WriteLine(name);
                }
            }

            string line = "";
            using (StreamReader sr = new StreamReader("name.txt"))
            {
                while((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            Console.ReadLine();
        }
    }
}
