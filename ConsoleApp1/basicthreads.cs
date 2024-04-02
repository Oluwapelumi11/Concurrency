using System;
using System.Diagnostics;
namespace faith
{
    class BasicThread
    {
        public static void Test(string[] args)
        {
            var watch = Stopwatch.StartNew();
            var t1 = new Thread(() => DoWork("Hi"));
            var t2 = new Thread(() => DoWork("Bye"));

            // or 
            //t1.Start("Hi");
            //t2.Start("Bye");

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            watch.Stop();

            Console.WriteLine($"It took {watch.Elapsed.Seconds} second(s) to complete");




            List<string> urls = new(){
            "https://www.google.com/",
            "https://www.duckduckgo.com/",
            "https://www.yahoo.com/",
            };
            List<Thread> threads = new List<Thread>();
            urls.ForEach(url => threads.Add(new Thread(() => CheckHttpStatus(url))));

            var stopwatch = Stopwatch.StartNew();

            threads.ForEach(threads => threads.Start());
            threads.ForEach(threads => threads.Join());

            stopwatch.Stop();

            Console.WriteLine($"It took {stopwatch.Elapsed.Seconds} second(s) to complete");


        }

        static void DoWork(object? arg)
        {
            if (arg == null)
                return;
            string message = (string)arg;
            Console.WriteLine(message);
            Thread.Sleep(1000);
            Console.WriteLine("Done");
        }


        static void CheckHttpStatus(string url)
        {
            HttpClient client = new();
            var response = client.GetAsync(url).Result;
            Console.WriteLine($"The url {url} has {response.StatusCode} as status code");
            client.Dispose();
        }
    }
}
