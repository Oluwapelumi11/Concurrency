using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrency
{
    internal class foreground_backgroundthread
    {
        public static void Test(string[] args)
        {
            var t = new Thread(DoWork);
        //changing the thread to background thread
        t.IsBackground = true;
            t.Start();

            for (int i = 0; i< 2; i++)
            {
                Console.WriteLine("Main thread running...");
                Thread.Sleep(100);
            }

}

static void DoWork()
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine("Foreground thread running...");
        Thread.Sleep(100);
    }
}
    }
}
