using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Concurrency
{
    internal class threadpool
    {

        public void pool()
        {
            List<string> urls = new(){
    "https://www.google.com/",
    "https://www.duckduckgo.com/",
    "https://www.yahoo.com/",
};

            foreach (var url in urls)
            {
                ThreadPool.QueueUserWorkItem((faith) => CheckHttpStatus(url));
            }
            Console.Read();
        }

        static void CheckHttpStatus(string url)
        {
            HttpClient client = new HttpClient();

        var response = client.GetAsync(url).Result;
        Console.WriteLine($"The url {url} says {response.StatusCode}");
        }
}
}

