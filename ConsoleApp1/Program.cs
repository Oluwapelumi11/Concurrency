using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace faith
{
    class Faith
    {
        public static void Main(string[] args)
        {
            int min = GetInt("Enter the minimum value> ");
            int max = GetInt("Enter the maximum value> ");

            var t = Task.Run(() =>  GetRandomNumber(min, max) );


            t.ContinueWith(tas  =>
            {
                Console.WriteLine($"The Random Number is {tas.Result}");
            },TaskContinuationOptions.OnlyOnRanToCompletion);

            t.ContinueWith((tas) =>
            {
                Console.WriteLine($"The code exited with status: {tas.Status}");
            }, TaskContinuationOptions.OnlyOnFaulted);

            Console.Read();
        }

       static int GetRandomNumber(int min, int max)
        {
            if(min > max)
            {
                throw new ArgumentException($"Error!!! minimum value {min} must be less than max value {max}");
            }
            Thread.Sleep(1500);

            return new Random().Next( min, max );
        }
       static int GetInt(string message)
        {
            int n = 0;
            while (true)
            {
                Console.Write(message);
                var num = Console.ReadLine();
                if(int.TryParse(num, out n))
                {
                    return n;
                }
            }
        }
    }
}
