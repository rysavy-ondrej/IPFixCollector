using IPFixCollector.NetflowCollection;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading;

namespace IPFixCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            void myHandler(object sender, ConsoleCancelEventArgs args)
            {
                Console.WriteLine("Stopping the worker...");
                args.Cancel = true;
                cts.CancelAfter(100);
            }

            Console.CancelKeyPress += new ConsoleCancelEventHandler(myHandler);

            var worker = new NetflowWorker(new System.Net.IPEndPoint(IPAddress.Any, 9996));
            worker.OnNetworkFlowDecoded += Worker_OnFlowArrival;
            worker.OnNetworkFlowMessageArrival += Worker_OnNetworkFlowMessageArrival;
            var task = worker.RunAsync(cts.Token);
            Console.WriteLine("Listening for IPFix Packets...");
            task.Wait();
            Console.WriteLine("Exit.");
        }

        private static void Worker_OnNetworkFlowMessageArrival(object sender, IPEndPoint networkFlowSource, ushort version)
        {
            Console.WriteLine($"Received v{version} from {networkFlowSource}:");
        }

        private static void Worker_OnFlowArrival(object sender, DataModel.NetworkFlow networkFlow)
        {
            Console.WriteLine($"{JsonConvert.SerializeObject(networkFlow, Formatting.Indented)}");
        }
    }
}
