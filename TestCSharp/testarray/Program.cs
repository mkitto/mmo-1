using System;

namespace testarray
{
    class Program
    {
        double addElements(params double[] arr)
        {
            double sum = 0;
            foreach(double i in arr)
            {
                sum += i;
            }
            return sum;
        }

        double getAverage(double[] arr)
        {
            double sum = 0;
            for (int i = 0; i < arr.Length; ++i)
            {
                sum += arr[i];
            }
            return sum/ arr.Length;
        }

        double getAverage(double[][] arr)
        {
            double sum = 0;
            int total = 0;
            for (int i = 0; i < arr.Length; ++i)
            {
                total += arr[i].Length;
                for (int j = 0; j < arr[i].Length; ++j)
                {
                    sum += arr[i][j];
                }
            }
            return sum / total;
        }

        static void Main(string[] args)
        {
            // 声明数组
            double[] array1;
            // 初始化数组
            double[] array2 = new double[3];
            // 赋值
            double[] array3 = { 1.0, 2.0, 3.0 };
            double[] array4 = new double[3] { 2.32, 3.23, 323.3 };
            double[] array5 = new double[] { 2.32, 3.23, 323.3 };
            array1 = array5;
            foreach (double i in array1)
            {
                Console.WriteLine( i);
            }

            array5[0] = 0;
            foreach (double i in array1)
            {
                Console.WriteLine(i);
            }

            for (int i = 0; i < array3.Length;  ++i)
            {
                Console.WriteLine("{0}: {1}", i, array3[i]);
            }

            // 多维数组
            double[,] array6 = new double[3, 3] { { 1.2, 2.3, 3.3 }, { 1.2, 2.3, 3.3 }, { 1.2, 2.3, 3.3 } };
            Console.WriteLine("the length of array6 is: " + array6.Length);  // Length是总的个数
            for (int i = 0; i < array6.GetLength(0); ++i)
            {
                for (int j = 0; j < array6.GetLength(1); ++j)
                {
                    Console.WriteLine("array6[{0}, {1}]: {2}", i, j, array6[i, j]);
                }
            }

            // 交错数组
            double[][] array7 = new double[][] { new double[] { 1.0, 2.0 }, new double[] { 3.0, 4.0 } };
            Console.WriteLine("the length of array7 is: " + array7.Length);  // Length是总的个数
            Console.WriteLine("array7.GetLength(): " + array7.GetLength(0));
            for (int i = 0; i < array7.Length; ++i)
            {
                for (int j = 0; j < array7[i].Length; ++j)
                {
                    Console.WriteLine("array7[{0}][{1}]: {2}", i, j, array7[i][j]);
                }
            }

            Program app = new Program();
            Console.WriteLine(app.getAverage(array4));
            Console.WriteLine(app.getAverage(array7));
            Console.WriteLine("AddElement: {0}", app.addElements(1.2, 2.3, 3.4));

            Console.WriteLine("Rank of arr4: {0}", array4.Rank);
            Console.WriteLine("Rank of arr6: {0}", array6.Rank);

            Array.Sort(array4, (x, y) => { return y.CompareTo(x); });  // lambda表达式
            for (int i = 0; i < array4.Length; ++i)
            {
                Console.WriteLine("{0}: {1}", i, array4[i]);
            }

            Console.ReadLine();
        }
    }
}
