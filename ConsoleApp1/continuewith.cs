using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrency
{
    internal class continuewith
    {
        public void lalala()
        {
            int result = 0;
            int result2 = 0;
            Task<int> task = Task.Run(() => GetSquareNum(10));

            // blocks the main thread from continuing;
            //result = task.Result;

            //to not block the main thread, we use continue with

            task.ContinueWith((task) =>
            {
                result = task.Result;
                Console.WriteLine($"Task1 result : {result}");
            });
            task.ContinueWith((task) =>
            {
                task = Task.Run(() => GetSquareNum(10));
            });
            task.ContinueWith((task) =>
            {
                result2 = task.Result;
                
            });

            while (result == 0)
            {
                Console.WriteLine("Waiting for result...");
                Thread.Sleep(1000);
            }
            while (result2 == 0)
            {
                Console.WriteLine("Waiting for result...");
                Thread.Sleep(1000);
            }
        }
        public static int GetSquareNum(int num)
        {
            Thread.Sleep(3000);
            return num * num;
        }
    }
}
