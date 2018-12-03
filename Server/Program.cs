using System;
using System.Net;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.Extensions.Logging;
using Orleans.Configuration;
using Orleans.Hosting;

namespace Server
{
    class Program
    {
        static async Task Main()
        {
            var builder = new SiloHostBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options => options.ClusterId = options.ServiceId = ClusterConstants.ServiceId)
                .Configure<EndpointOptions>(options => options.AdvertisedIPAddress = IPAddress.Loopback)
                .ConfigureLogging(logging => logging.AddConsole());

            using (var host = builder.Build())
            {
                await host.StartAsync();

                do
                {
                    Console.WriteLine("Press escape to exit");
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

                await host.StopAsync();
            }
        }
    }
}
