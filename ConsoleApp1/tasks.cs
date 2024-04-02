using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrency
{
    internal class tasks
    {
        //var task = new Task(() => GetRandomNumber());

        //task.Start();

        //using the run static method

        //returns a type of task int; use result to get the value
        //Task<int> task = Task.Run(() => GetRandomNumber());
        // or usee the startnew method of the task factory object
        static void help()
        {
            Task<int> task = Task.Factory.StartNew(() => GetRandomNumber());

            Console.WriteLine(task.Result);
            //Console.WriteLine("Starting the Program");
            Console.Read();

        }


        static int GetRandomNumber()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            var threadpool = Thread.CurrentThread.IsThreadPoolThread;

            Console.WriteLine($"Current #{threadId} uses a threadpool {threadpool}");

            Thread.Sleep(1000);
            int randomNum = new Random().Next(1, 100);
            //Console.WriteLine($"The number is {randomNum}");
            return randomNum;
        }
    }
}
