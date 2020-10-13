using System;

namespace testexception
{
    class Temperature
    {
        int temperature = 0;
        public void showTemp()
        {
            if (temperature == 0)
            {
                throw (new TemperatureIsZero("Zero Temprature found"));
            }
            else
            {
                Console.WriteLine("Temperature is {0}", temperature);
            }
        }
    }

    class TemperatureIsZero: ApplicationException
    {
        public TemperatureIsZero(string message): base(message)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //int a, b;
            //int result = 0;
            //a = Convert.ToInt32(Console.ReadLine());
            //b = Convert.ToInt32(Console.ReadLine());
            //try
            //{
            //    result = a / b;
            //}
            //catch(DivideByZeroException e)
            //{
            //    Console.WriteLine("Exception catch: {0}", e);
            //}
            //finally
            //{
            //    Console.WriteLine("Result: {0} {1} {2}", result, a , b);
            //}
            try
            {
                Temperature obj = new Temperature();
                obj.showTemp();
            }
            catch(TemperatureIsZero e)
            {
                Console.WriteLine("TemperatureIsZeroException: {0}", e.Message);
            }
            Console.ReadLine();
        }
    }
}
